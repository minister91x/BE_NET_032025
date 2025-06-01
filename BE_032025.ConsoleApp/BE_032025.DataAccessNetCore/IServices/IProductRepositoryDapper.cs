using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.RequestData;

namespace BE_032025.DataAccessNetCore.IServices
{
    public interface IProductRepositoryDapper
    {
        Task<List<ProductDTO>> Product_GetList(Product_GetListRequestData requestData);
        Task<ReturnData> Product_Insert(Product_InsertRequestData requestData);
    }
}
