using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.DataObject
{
    public class User_Sessions
    {
        public int AccountID { get; set; }
        public string? Token { get; set; }
        public string? DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public DateTime? ExpriredTime { get; set; }
    }
}
