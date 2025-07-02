using System.Diagnostics;
using BE_032025.NetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            var list = new List<ProductDemoModels>();
            try
            {
                // Nó sẽ đi tìm trong thư mục Views sẽ đi tiếp thư mục có tên trùng với tên của controller 
                // đi tìm thư mục home trong thư mục views / Views/Home 
                // và tìm file có tên trùng với tên của ActionResult => là Index.cshtml
                
                list.Add(new ProductDemoModels
                {
                    Id = 1,
                    Name = "Iphone 14 Pro Max",
                    Image = "https://cdn.tgdd.vn/Products/Images/42/289663/Kit/iphone-14-note-new-1.jpg"
                });

            }
            catch (Exception)
            {

                throw;
            }
            return View(list);
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
