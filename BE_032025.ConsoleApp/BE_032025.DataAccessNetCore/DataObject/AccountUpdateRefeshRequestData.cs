using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.DataObject
{
    public class AccountUpdateRefeshRequestData
    {
        public int AccountID { get; set; }
        public DateTime ExpriedTime { get; set; }
        public string? ResfeshToken { get; set; }
    }
}
