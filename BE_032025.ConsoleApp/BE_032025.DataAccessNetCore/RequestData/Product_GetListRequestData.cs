using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccessNetCore.RequestData
{
    public class Product_GetListRequestData
    {
        public int ProductID { get; set; }  
    }

    public class Product_InsertRequestData
    {
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int CategoryID { get; set; }
    }
    
}
