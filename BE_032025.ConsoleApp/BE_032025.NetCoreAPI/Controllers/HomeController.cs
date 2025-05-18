using System.Diagnostics;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;
using BE_032025.DataAccessNetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private readonly IProductRepository _productServices;
        //private readonly IProductGenericRepository _productGenericServices;
        //public HomeController(IProductRepository productServices, IProductGenericRepository productGenericServices)
        //{
        //  _productServices = productServices;
        //    _productGenericServices = productGenericServices;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Product_GetList")]
        public async Task<IActionResult> Product_GetList(Product_GetListRequestData requestData)
        {
            try
            {
                // var list = await _productServices.Product_GetList_EfCore(requestData);

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var list = await _unitOfWork.ProductGenericRepository.GetList(requestData);
                stopwatch.Stop();
                Console.WriteLine($"AsNoTracking: {stopwatch.ElapsedMilliseconds} ms");


                var stopwatch2 = new Stopwatch();
                var list_NoTracking = await _unitOfWork.ProductGenericRepository.GetList_NoATracking(requestData);

                stopwatch2.Stop();
                Console.WriteLine($"Tracking: {stopwatch2.ElapsedMilliseconds} ms");


                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost("Product_Insert")]
        public async Task<IActionResult> Product_Insert(Product_InsertRequestData requestData)
        {
            try
            {

                // Check dữ liệu đầu vào

                if (string.IsNullOrEmpty(requestData.ProductName))
                {
                    return BadRequest("Tên sản phẩm không được để trống");
                }

                // Kiểm tra độ dài tên sản phẩm
                if (requestData.ProductName.Length > 250)
                {
                    return BadRequest("Tên sản phẩm không được quá 250 ký tự");
                }

                // Kiểm tra XSS
                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.ProductName))
                {
                    return BadRequest("Tên sản phẩm không hợp lệ");
                }


                var rs_product = await _unitOfWork.ProductGenericRepository.Insert(
                    new Product
                    {
                        ProductName = requestData.ProductName,
                        ProductImage = requestData.ProductImage,
                        CategoryID = requestData.CategoryID
                    });

                var rs = await _unitOfWork.CategoryRepository.Insert(
                    new Category
                    {
                        CategoryName = "Category 1234",
                    });


                await Task.Delay(300000);

                _unitOfWork.SaveChange();


                // var list = await _unitOfWork.ProductGenericRepository.Insert(requestData);
                // return Ok(list);

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
