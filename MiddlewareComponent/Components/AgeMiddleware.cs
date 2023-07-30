using Microsoft.Extensions.Primitives;

namespace MiddlewareComponent.Components
{
    public class AgeMiddleware
    {
        private readonly RequestDelegate _next;
        public AgeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            StringValues temp = context.Request.Query["age"];
            StringValues name = context.Request.Query["name"];
            var age = string.IsNullOrEmpty(temp) ? 0 : Convert.ToInt32(temp);
            if (string.IsNullOrEmpty(name))
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("Enter your name");
            }
            else
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                string html = $"Hello, {name}. Your age is {age}.";
                await context.Response.WriteAsync(html);
                await _next.Invoke(context);
            }
        }
    }
}
