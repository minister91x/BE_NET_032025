using System.Linq;
using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BE_032025.NetCoreAPI.Filter
{
    // Attribute để đánh dấu các action cần phải được xác thực
    public class BE_032025_AuthorizeAttribute : TypeFilterAttribute
    {
        public BE_032025_AuthorizeAttribute(string _functionCode, string _permession) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { _functionCode, _permession };

        }
    }

    public class AuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        private string _functionCode { get; set; }
        private string _permession { get; set; }

        public AuthorizeActionFilter(string functionCode, string permession)
        {
            _functionCode = functionCode;
            _permession = permession;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated)
            {
                // Nếu không có xác thực, trả về Unauthorized
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { message = "Vui lòng đăng nhập để thực hiện chức năng này!" });
                return;
            }


            var userClaims = identity.Claims;
            var UserID = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value);
            var IsAdmin = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.IsPersistent)?.Value);

            // Checkpermission 
            // Gọi DB 
            // bước 1 : Từ _functionCode => FUNCTIONID 
            // BƯỚC 2 : UserID + FUNCTIONID => QUYỀN 

            if (IsAdmin != 1)
            {
                // Khác admin thì check quyền 
                switch (_permession)
                {
                    case "ISVIEWS": //Check quyền views
                        break;

                    case "ISINSERT": //Check quyền INSERT
                        break;

                    case "ISUPDATE": //Check quyền UPDATE
                        break;

                    case "ISDELETE": //Check quyền DELETE
                        break;
                }
            }
        }
    }
}
