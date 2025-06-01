using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.Enums;
using BE_032025.DataAccessNetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BE_032025.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAcccountRepository _acccountRepository;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        public AuthenController(IAcccountRepository acccountRepository,
            IConfiguration configuration, IDistributedCache cache)
        {
            _acccountRepository = acccountRepository;
            _configuration = configuration;
            _cache = cache;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AccountLoginRequestData requestData)
        {
            var returnData = new AccountLoginResponse();
            try
            {
                // Bước 1: CheckLogin

                if (string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Tên hoặc mật khẩu đăng nhập không đúng";
                    return Ok(returnData);
                }

                var account = await _acccountRepository.Account_Login(requestData);

                if (account == null)
                {
                    returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Tên hoặc mật khẩu đăng nhập không đúng";
                    return Ok(returnData);
                }

                // Bước 2 : tạo token   
                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.PrimarySid, account.AccountID.ToString()),
                    new Claim(ClaimTypes.IsPersistent, account.IsAdmin.ToString())
                };


                var tokenNew = CreateToken(authClaims);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenNew);

                // tạo luôn Refeshtoken 
                var resfeshToken = GenerateRefreshToken();

                // lấy expired refesh token từ config

                var expiredRefreshToken = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]));
                // lưu vào db

                var updateRefeshToken = await _acccountRepository.Account_Update_RefeshToken(new AccountUpdateRefeshRequestData
                {
                    AccountID = account.AccountID,
                    ResfeshToken = resfeshToken,
                    ExpriedTime = expiredRefreshToken
                });


                // Lưu token vào Redis . Với thời gian sống = thời hạn của token
                var userSession = new BE_032025.DataAccess.DataObject.User_Sessions
                {
                    AccountID = account.AccountID,
                    Token = token,
                    ExpriredTime = tokenNew.ValidFrom,
                    DeviceID = requestData.DeviceID,
                };

                var keyCache = $"User_Session_" + account.AccountID + "_" + requestData.DeviceID;
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) // Thời gian hết hạn cache
                };

                await _cache.SetStringAsync(keyCache, JsonConvert.SerializeObject(userSession), cacheOptions);

              

                // bước 3 trả về token 
                returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_INSERT_SUCCESS;
                returnData.token = token;
                returnData.UserName = account.UserName;
                returnData.AccountID = account.AccountID;
                returnData.FullName = account.FullName;
                returnData.resfeshToken = resfeshToken;
                returnData.ResponseMessage = "Đăng nhập thành công";


                return Ok(returnData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            // giải mã token 
            var principal = GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {// không giải mã được tọken
                return BadRequest("Invalid access token or refresh token");
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            // lấy cái Name từ identity trong hàm giải mã token
            string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var user = await _acccountRepository.Account_GetByUserName(username);

            if (user == null || user.RefreshToken != refreshToken || user.ExpriredTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            var expiredRefreshToken = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]));
            await _acccountRepository.Account_Update_RefeshToken(new AccountUpdateRefeshRequestData
            {
                AccountID = user.AccountID,
                ExpriedTime = expiredRefreshToken,
                ResfeshToken = newRefreshToken
            });


            // xóa cache của token cũ đi 

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
