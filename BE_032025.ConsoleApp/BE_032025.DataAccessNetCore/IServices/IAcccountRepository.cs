using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;

namespace BE_032025.DataAccessNetCore.IServices
{
    public interface IAcccountRepository
    {
        Task<Account> Account_Login(AccountLoginRequestData requestData);
        Task<int> Account_Update_RefeshToken(AccountUpdateRefeshRequestData requestData);
        Task<Account> Account_GetByUserName(string UserName);
    }
}
