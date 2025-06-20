﻿using System.Diagnostics;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;
using BE_032025.DataAccessNetCore.UnitOfWork;
using BE_032025.NetCoreAPI.NLogManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggerManager _loggerManager;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;
        public HomeController(IUnitOfWork unitOfWork, IDistributedCache cache,
            ILogger<HomeController> logger, ILoggerManager loggerManager)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
            _loggerManager = loggerManager;
        }

        [HttpPost("Product_GetList")]
        // Filter -> Claims 
        // Bươc 1: Tạo Filter (Attributes)
        // Bước 2 Impliment Interface IAuthorization trong Attributes
        // Bước 3: Đọc Identity Trong hàm override của IAuthorization
        // Bước 4 :Đọc Claims trong identity
        [BE_032025.NetCoreAPI.Filter.BE_032025_Authorize("Product_GetList", "ISVIEWS")]

        // Chức năng 
        // UserId 
        public async Task<IActionResult> Product_GetList(Product_GetListRequestData requestData)
        {
            try
            {

                var UserID = AccountInfor.AccountID;


                _loggerManager.LogInfo("Product_GetList requestData: " + JsonConvert.SerializeObject(requestData));

                // var list = await _productServices.Product_GetList_EfCore(requestData);

                //var stopwatch = new Stopwatch();
                //stopwatch.Start();
                //  var list = await _unitOfWork.ProductGenericRepository.GetList(requestData);
                //stopwatch.Stop();
                //Console.WriteLine($"AsNoTracking: {stopwatch.ElapsedMilliseconds} ms");


                //var stopwatch2 = new Stopwatch();
                //var list_NoTracking = await _unitOfWork.ProductGenericRepository.GetList_NoATracking(requestData);

                //stopwatch2.Stop();
                //Console.WriteLine($"Tracking: {stopwatch2.ElapsedMilliseconds} ms");

                // Bước 1: Kiểm tra dữ liệu trong cache

                //nêu dữ liệu đã có trong cache thì trả về dữ liệu từ cache
                var keyCache = "Product_GetList";
                var cachedData = await _cache.GetStringAsync(keyCache);
                if (!string.IsNullOrEmpty(cachedData))
                {
                    // Chuyển đổi dữ liệu từ JSON về List<Product>
                    var cachedList = JsonConvert.DeserializeObject<List<Product>>(cachedData);
                    _loggerManager.LogInfo("Product_GetList Response :" + JsonConvert.SerializeObject(cachedList));
                    return Ok(cachedList);
                }

                // nếu dữ liệu không có trong cache thì truy vấn từ DB và lưu vào cache
                // đi vào database để lấy 
                var list = await _unitOfWork.ProductGenericRepository.GetList(requestData);
                // lưu dữ liệu vào cache
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) // Thời gian hết hạn cache
                };

                await _cache.SetStringAsync(keyCache, JsonConvert.SerializeObject(list), cacheOptions);

                // _logger.LogInformation("Dữ liệu đã được lưu vào cache với key: {Key}", keyCache +" |Data:"+ JsonConvert.SerializeObject(list));
                _loggerManager.LogInfo("Product_GetList Response :" + JsonConvert.SerializeObject(list));

                return Ok(list);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ex Message:"+ ex.Message + " | StackTrace: " + ex.StackTrace);
                throw ex; // Ném lại ngoại lệ để xử lý ở nơi khác nếu cần
            }
        }


        [HttpPost("Product_Insert")]
        public async Task<IActionResult> Product_Insert([FromBody] Product_InsertRequestData requestData)
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


                var rs_product = await _unitOfWork.ProductRepositoryDapper.Product_Insert(
                    new Product_InsertRequestData
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


                ///  await Task.Delay(300000);

                _unitOfWork.SaveChange();


                // var list = await _unitOfWork.ProductGenericRepository.Insert(requestData);
                // return Ok(list);

                return Ok(rs_product);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
