using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Leader.Integration.Authorization
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next, IConfiguration appSettings
            )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userId = context.Items["Admin"];
            if (userId != null)
            {
                context.Items["Admin"] = userId;
            }

            await _next(context);
        }
    }
}
