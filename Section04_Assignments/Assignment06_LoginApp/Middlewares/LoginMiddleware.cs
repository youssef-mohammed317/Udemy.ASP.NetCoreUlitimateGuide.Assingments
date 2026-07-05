using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Assignment06_LoginApp.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class LoginMiddleware
{
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Method == "POST" && httpContext.Request.Path == "/")
        {
            using var reader = new StreamReader(httpContext.Request.Body);
            var bodyText = await reader.ReadToEndAsync();

            var dic = bodyText.Split("&").ToDictionary(x => x.Split("=").Count() > 0 ? x.Split("=")[0] : "", x => x.Split("=").Count() > 1 ? x.Split("=")[1] : "");

            string? email = dic.ContainsKey("email") ? dic["email"] : null;
            string? password = dic.ContainsKey("password") ? dic["password"] : null;

            if (email == null || password == null)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync("Invalid input for 'email' or 'password'");
            }
            else if (email != "admin@example.com" || password != "admin1234")
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync("Invalid login");

            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsJsonAsync("Login Successful");

            }
            return;
        }
        else if (httpContext.Request.Method == "GET" && httpContext.Request.Path == "/")
        {
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            return;
        }
        await _next(httpContext);

    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class LoginMiddlewareExtensions
{
    public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginMiddleware>();
    }
}
