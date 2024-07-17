using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

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
