using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.CustomExceptions;

namespace OrdersWebApi.CustomMiddlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task Invoke(HttpContext context)
    {
        try
        {
            _logger.LogInformation("Start the request");
            await _next(context);
            _logger.LogInformation("End of the request successfully");
        }
        catch (CustomValidationException ex)
        {
            LogException(ex);
            await WriteProblemDetails(context, StatusCodes.Status400BadRequest, "Validation Error", ex.Message, ex.Errors);
        }
        catch (ResourceNotFoundException ex)
        {
            LogException(ex);
            await WriteProblemDetails(context, StatusCodes.Status404NotFound, "Resource Not Found", ex.Message);
        }
        catch (Exception ex)
        {
            LogException(ex);
            await WriteProblemDetails(context, StatusCodes.Status500InternalServerError, "Server Error", "An unexpected error occurred.");
        }
    }

    private static async Task WriteProblemDetails(
        HttpContext context, int statusCode, string title, string detail,
        IDictionary<string, string[]>? errors = null)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = statusCode;

        ProblemDetails problem = errors != null
            ? new ValidationProblemDetails(errors) { Status = statusCode, Title = title, Detail = detail }
            : new ProblemDetails { Status = statusCode, Title = title, Detail = detail };

        await context.Response.WriteAsJsonAsync(problem);
    }

    private void LogException(Exception ex)
    {
        _logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
        if (ex.InnerException != null)
        {
            _logger.LogError($"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}");
        }
    }
}

// Extension method used to add the exception handling middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
