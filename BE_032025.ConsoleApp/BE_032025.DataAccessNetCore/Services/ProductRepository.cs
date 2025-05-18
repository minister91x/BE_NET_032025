using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.Dbcontext;
using BE_032025.DataAccessNetCore.Enums;
using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;

namespace BE_032025.DataAccessNetCore.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly BE_032025DbContext _dbContext;
        public ProductRepository(BE_032025DbContext dbContext)
        {
            _dbContext = dbContext;
        }
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

        public async Task<List<Product>> Product_GetList_EfCore(Product_GetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                list = _dbContext.product.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        public async Task<ReturnData> Product_Insert(Product_InsertRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // Bươc 1 : kiểm tra dữ liệu đầu vào 
                if (string.IsNullOrEmpty(requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }

                if (requestData.ProductName.Length > 250)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }


                // Kiểm tra XSS
                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }

                // Bước 2: Kiểm tra trùng dữ liệu
                //Cách 2.1
                var isDuplicate = _dbContext.product.Any(x => x.ProductName == requestData.ProductName);

                // Cách 2.2
                //var isDuplicate = false;
                //var list = _dbContext.product.ToList();
                //if(list.Count > 0)
                //{
                //    foreach (var item in list)
                //    {
                //        if (item.ProductName == requestData.ProductName)
                //        {
                //            isDuplicate = true;
                //            break;
                //        }
                //    }   
                //}

                if (isDuplicate)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product isDuplicate";
                    return returnData;
                }


                // Bước 3: Insert dữ liệu

                var product = new Product();
                product.ProductName = requestData.ProductName;
                product.CategoryID = 1;

                _dbContext.product.Add(product);
                _dbContext.SaveChanges();

                returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_INSERT_SUCCESS;
                returnData.ResponseMessage = "Product insert successfull";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
