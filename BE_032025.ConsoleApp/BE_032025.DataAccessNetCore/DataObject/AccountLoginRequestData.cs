using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.DataObject
{
    public class AccountLoginRequestData
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? DeviceID { get; set; } // Thêm DeviceID nếu cần thiết
    }
}
