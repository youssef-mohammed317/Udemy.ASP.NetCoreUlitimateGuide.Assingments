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
        catch (ArgumentNullException ex)
        {
            LogException(ex);

        }
        catch (CustomValidationException ex)
        {
            LogException(ex);
        }
        catch (ResourceNotFoundException ex)
        {
            LogException(ex);

        }
        catch (Exception ex)
        {
            LogException(ex);
        }
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
