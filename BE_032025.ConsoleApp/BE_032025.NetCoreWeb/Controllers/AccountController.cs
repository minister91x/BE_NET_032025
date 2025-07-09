using BE_032025.NetCoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            // Trả về view đăng nhập
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInRequestData requestData)
        {
            try
            {
                if (string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    ViewBag.Notice = "Email hoặc mật khẩu không được để trống";
                    return View();
                }

              

                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.UserName)
                    || !BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.Password))
                {
                    ViewBag.Notice = "Email hoặc mật khẩu không hợp lệ";
                    return View();
                }

                // Giả sử bạn có một phương thức để xác thực người dùng


                ViewBag.Notice = "Đăng nhập thành công với email: " + requestData.UserName;
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }


        [HttpPost]
        public IActionResult Login_AJAX([FromBody] LogInRequestData requestData)
        {
            try
            {
                if (string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    return Json(new { ResponseCode = -1, Message = "Dữ liệu không hợp lệ" });
                }

                

                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.UserName)
                    || !BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.Password))
                {
                    return Json(new { ResponseCode = -2, Message = "tài khoản hoặc mật khẩu không hợp lệ" });
                }

                // Giả sử bạn có một phương thức để xác thực người dùng
                var URL = _configuration["API_URL:BaseUrl"]+ "/api/Authen/Login"; // Đặt URL của API bạn muốn gọi
                var RequestDataJson = System.Text.Json.JsonSerializer.Serialize(requestData);

                var resultJson =  BE_032025.CommonNetcore.HttpHelper.HttpPost(URL, RequestDataJson);
                var result = System.Text.Json.JsonSerializer.Deserialize<AccountLoginResponse>(resultJson);

                HttpContext.Session.SetString("login", result.AccountID.ToString());


                return Json(result);


            }
            catch (Exception ex)
            {
                return Json(new { ResponseCode = -2, Message = ex.Message });
            }

        }

    }
}
