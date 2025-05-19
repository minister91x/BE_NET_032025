using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.DataObject
{
    public class Account
    {
        public int AccountID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? FullName { get; set; }
        public int IsAdmin { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? ExpriredTime { get; set; } 
    }
}
