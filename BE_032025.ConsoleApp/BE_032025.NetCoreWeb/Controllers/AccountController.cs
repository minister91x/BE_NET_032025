using BE_032025.NetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            // Trả về view đăng nhập
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInRequestData requestData)
        {
            try
            {
                if (string.IsNullOrEmpty(requestData.email)
                    || string.IsNullOrEmpty(requestData.password))
                {
                    ViewBag.Notice = "Email hoặc mật khẩu không được để trống";
                    return View();
                }

                if (!requestData.email.Contains("@"))
                {
                    ViewBag.Notice = "Email không hợp lệ";
                    return View();
                }

                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.email)
                    || !BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.password))
                {
                    ViewBag.Notice = "Email hoặc mật khẩu không hợp lệ";
                    return View();
                }

                // Giả sử bạn có một phương thức để xác thực người dùng


                ViewBag.Notice = "Đăng nhập thành công với email: " + requestData.email;
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }


        [HttpPost]
        public IActionResult Login_AJAX([FromBody] LogInRequestData requestData)
        {
            try
            {
                if (string.IsNullOrEmpty(requestData.email)
                    || string.IsNullOrEmpty(requestData.password))
                {
                    return Json(new { ResponseCode = -1, Message = "Dữ liệu không hợp lệ" });
                }

                if (!requestData.email.Contains("@"))
                {
                    return Json(new { ResponseCode = -3, Message = "Email không hợp lệ" });
                }

                if (!BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.email)
                    || !BE_032025.CommonNetcore.Sercurity.CheckXSSInput(requestData.password))
                {
                    return Json(new { ResponseCode = -2, Message = "Email hoặc mật khẩu không hợp lệ" });
                }

                // Giả sử bạn có một phương thức để xác thực người dùng

                return Json(new { ResponseCode = 1, Message = "Đăng nhập thành công với email: " + requestData.email });


            }
            catch (Exception ex)
            {
                return Json(new { ResponseCode = -2, Message = ex.Message });
            }

        }

    }
}
