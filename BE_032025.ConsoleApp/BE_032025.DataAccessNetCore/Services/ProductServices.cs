using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;

namespace BE_032025.DataAccessNetCore.Services
{
    public class ProductServices : IProductServices
    {
        public async Task<List<ProductDTO>> Product_GetList(Product_GetListRequestData requestData)
        {
            var list = new List<ProductDTO>();
            try
            {
               await Task.Yield();

                for (int i = 0; i < 10; i++)
                {
                    var product = new ProductDTO();
                    product.ProductID = i;
                    product.ProductName = "Product " + i;
                    product.CategoryName = "Category " + i;
                    list.Add(product);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        public async Task<int> Product_Insert(Product_InsertRequestData requestData)
        {
            throw new NotImplementedException();
        }
    }
}
