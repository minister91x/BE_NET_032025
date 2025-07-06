using BE_032025.NetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreWeb.Controllers
{
    public class ProductController : Controller
    {
        //[NonAction]
        public IActionResult Index(int? abc)
        {
            // Trả về được nhiều định dạng hơn views / redirecttoaction , json , file, content,
            return Json(new { message = "Hello from ProductController" });
        }

        [HttpPost("Index")]
        public IActionResult Index(List<ProductDemoModels> model)
        {
            // Trả về được nhiều định dạng hơn views / redirecttoaction , json , file, content,
            return View();
        }

       [HttpPost()]
        public IActionResult ProductGetList([FromBody] ProductGetListModels requestData)
        {
            // nếu truyền xuống dạng Json thì sẽ phải có thêm đánh dấu là FromBody
            // nếu truyên xuống dạng file thì sẽ phải có thêm đánh dấu là FromForm

            // trả về viewsrÉ / json / redirecttoaction
            var list = new List<ProductDemoModels1>
            {
                new ProductDemoModels1
                {
                    Id = 1,
                    Name = "Iphone 14 Pro Max",
                    Image = "https://cdn.tgdd.vn/Products/Images/42/289663/Kit/iphone-14-note-new-1.jpg"
                },
                new ProductDemoModels1
                {
                    Id = 2,
                    Name = "Iphone 15 Pro Max",
                    Image = "https://cdn.tgdd.vn/Products/Images/42/289663/Kit/iphone-14-note-new-1.jpg"
                }
            };

             var result = list.FindAll(s => s.Id == requestData.Id).ToList();
            return Json(result);
            //return View();
        }
    }
}
