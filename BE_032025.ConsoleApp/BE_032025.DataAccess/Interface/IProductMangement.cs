using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccess.Class;
using BE_032025.DataAccess.RequestData;

namespace BE_032025.DataAccess.Interface
{
    public interface IProductMangement
    {
        List<Product_GetListResponseData> Product_GetList(Product_GetListRequestData requestData);
        int Product_Insert(Product_InsertRequestData requestData);
    }
}
