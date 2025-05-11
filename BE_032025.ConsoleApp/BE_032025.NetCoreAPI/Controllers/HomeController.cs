using BE_032025.DataAccessNetCore.IServices;
using BE_032025.DataAccessNetCore.RequestData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_032025.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public HomeController(IProductServices productServices)
        {
          _productServices = productServices;
        }


        [HttpPost("Product_GetList")]
        public async Task<IActionResult> Product_GetList(Product_GetListRequestData requestData)
        {
            try
            {
                var list = await _productServices.Product_GetList_EfCore(requestData);
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
                var list = await _productServices.Product_Insert(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
