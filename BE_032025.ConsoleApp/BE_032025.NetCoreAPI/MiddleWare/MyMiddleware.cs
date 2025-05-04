namespace BE_032025.NetCoreAPI.MiddleWare
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-My-Custom-Header", "TEST 133");
            httpContext.Response.Headers.Add("Hackby", "MRQUAN");
            return _next(httpContext);
        }

    }
}
