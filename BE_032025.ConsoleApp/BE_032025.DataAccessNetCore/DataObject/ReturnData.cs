using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.DataObject
{
    public class ReturnData
    {
        public int ResponseCode  { get; set; }
        public string? ResponseMessage { get; set; }
    }
}
