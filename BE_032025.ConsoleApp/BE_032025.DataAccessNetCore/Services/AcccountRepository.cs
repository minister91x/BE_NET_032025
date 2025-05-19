using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.CommonNetcore;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.Dbcontext;
using BE_032025.DataAccessNetCore.IServices;

namespace BE_032025.DataAccessNetCore.Services
{
    public class AcccountRepository : IAcccountRepository
    {
        private readonly BE_032025DbContext _context;
        public AcccountRepository(BE_032025DbContext context)
        {
            _context = context;
        }

        public async Task<Account> Account_GetByUserName(string UserName)
        {
            return _context.account.Where(s => s.UserName == UserName).FirstOrDefault();
        }

        public async Task<Account> Account_Login(AccountLoginRequestData requestData)
        {
            try
            {
                if (requestData == null
                   || string.IsNullOrEmpty(requestData.UserName)
                   || string.IsNullOrEmpty(requestData.Password))
                {
                    throw new Exception("Dữ liệu đầu vào không hợp lệ");
                }

                var passwordHash = Sercurity.ComputeSha256Hash(requestData.Password);

                return _context.account?.FirstOrDefault(x => x.UserName == requestData.UserName
           && x.Password == passwordHash);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<int> Account_Update_RefeshToken(AccountUpdateRefeshRequestData requestData)
        {
            try
            {
                var account = _context.account?.FirstOrDefault(x => x.AccountID == requestData.AccountID);
                if (account == null)
                {
                    throw new Exception("Tài khoản không tồn tại");
                }
                account.AccountID = requestData.AccountID;
                account.RefreshToken = requestData.ResfeshToken;
                account.ExpriredTime = requestData.ExpriedTime;
                 _context.account.Update(account);

                return await _context.SaveChangesAsync();
            }
            catch (Exception exx)
            {

                throw;
            }
        }
    }

}
