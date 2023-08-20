using Newtonsoft.Json;
using Ratsatak.Application.Common.Errors;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Ratsatak.Api.Common.Errors;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ILogger _logger = Log.Logger.ForContext<ErrorHandlingMiddleware>();

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var (statusCode, title, detail, stackTrace) = exception switch
        {
            IApplicationException serviceException => ((int)serviceException.StatusCode, serviceException.Title,
                serviceException.Detail, exception.StackTrace),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred", exception.Message,
                exception.StackTrace)
        };

        var response = new
        {
            title,
            status = statusCode,
            detail,
            stackTrace
        };
        
        _logger.Error(
            "ApiError --> title: {@Title} | statusCode: {@StatusCode} | title: {@Title} | detail: {@Detail} | stackTrace: {@StackTrace}",
            title,
            statusCode,
            title,
            detail,
            stackTrace);

        var result = JsonConvert.SerializeObject(response);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        return httpContext.Response.WriteAsync(result);
    }
}