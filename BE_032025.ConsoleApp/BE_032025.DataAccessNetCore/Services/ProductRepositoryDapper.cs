using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;
using BE_032025.DataAccessNetCore.BaseApplication;
using BE_032025.CommonNetcore;
using Dapper;
using System.Data;
using System.Reflection.Metadata;

namespace BE_032025.DataAccessNetCore.Services
{
    public class ProductRepositoryDapper : BaseApplicationService, IProductRepositoryDapper
    {
        public ProductRepositoryDapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<ProductDTO>> Product_GetList(Product_GetListRequestData requestData)
        {
            return await DbConnection.QueryAsync<ProductDTO>("SP_Product_GetList", requestData);
        }

        public async Task<ReturnData> Product_Insert(Product_InsertRequestData requestData)
        {
            var returnData = new ReturnData();

            if (requestData == null
                || string.IsNullOrEmpty(requestData.ProductName)
                || requestData.CategoryID <= 0)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Invalid input data";
                return returnData;
            }

            // Check for XSS
            if (!Sercurity.CheckXSSInput(requestData.ProductName))
            {
                returnData.ResponseCode = -2;
                returnData.ResponseMessage = "Invalid product name";
                return returnData;
            }


            var parameters = new DynamicParameters();

            parameters.Add("@ProductName", requestData.ProductName);// HƯỚNG TỪ C# ĐẾN SQL SERVER
            parameters.Add("@ProductImage", requestData.ProductImage);
            parameters.Add("@CategoryID", requestData.CategoryID);
            parameters.Add("@ResponseCode",SqlDbType.Int, direction: ParameterDirection.Output); // HƯỚNG TỪ SQL SERVER ĐẾN C#
            var result = await DbConnection.ExecuteAsync("SP_Product_Insert", parameters);

            var responseCode = parameters.Get<int>("@ResponseCode");

            if (responseCode > 0)
            {
                returnData.ResponseCode = 1;
                returnData.ResponseMessage = "Thêm sản phẩm thành công !";
                return returnData;
            }
            else
            {

                switch (responseCode)
                {
                    case -1:
                        returnData.ResponseCode = -1;
                        returnData.ResponseMessage = "Dữ liệu đầu vào không hợp lệ";
                        return returnData;
                    case -2:
                        returnData.ResponseCode = -2;
                        returnData.ResponseMessage = "Tên sản phẩm đã tồn tại";
                        return returnData;
                    case -3:
                        returnData.ResponseCode = -3;
                        returnData.ResponseMessage = "Danh mục sản phẩm không tồn tại";
                        return returnData;
                    default:
                        returnData.ResponseCode = -969;
                        returnData.ResponseMessage = "Hệ thống đang bận. Vui lòng quay lại sau ";
                        return returnData;
                }
            }
            
        }
    }
}
