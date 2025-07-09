using System.Collections.Generic;
using System.Diagnostics;
using BE_032025.NetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE_032025.NetCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index(int? id)
        {
            var session = HttpContext.Session.GetString("login") ?? "";
            if (string.IsNullOrEmpty(session))
            {
                return Redirect("/Account/Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Product_InsertRequestData requestData)
        {
            var desc = string.Empty;
            try
            {
                var URL = _configuration["API_URL:BaseUrl"] + "/api/Home/Product_Insert"; // Đặt URL của API bạn muốn gọi
                var RequestDataJson = System.Text.Json.JsonSerializer.Serialize(requestData);
                var token = Request.Cookies["BE_032025_Token"] ?? "";
                var resultJson = BE_032025.CommonNetcore.HttpHelper.HttpPostWithToken(URL, token, RequestDataJson);
                var result = JsonConvert.DeserializeObject<ReturnData>(resultJson);

                ViewBag.desc = result.ResponseMessage;

            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

        [HttpPost()]
        public IActionResult _ListProductPartialViews([FromBody] Product_GetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                var URL = _configuration["API_URL:BaseUrl"] + "/api/Home/Product_GetList"; // Đặt URL của API bạn muốn gọi
                var RequestDataJson = System.Text.Json.JsonSerializer.Serialize(requestData);
                var token = Request.Cookies["BE_032025_Token"] ?? "";
                var resultJson = BE_032025.CommonNetcore.HttpHelper.HttpPostWithToken(URL, token, RequestDataJson);
                list = JsonConvert.DeserializeObject<List<Product>>(resultJson);

            }
            catch (Exception)
            {

                throw;
            }
            return PartialView(list);
        }




        public IActionResult Privacy()
        {
            //return RedirectToAction("About");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
