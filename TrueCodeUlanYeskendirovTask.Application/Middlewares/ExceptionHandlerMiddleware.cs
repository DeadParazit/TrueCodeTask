using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrueCodeUlanYeskendirovTask.Service.Exceptions;

namespace TrueCodeUlanYeskendirovTask.Service.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        switch (exception)
        {
            case ArgumentException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case CustomNotFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }
    
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}