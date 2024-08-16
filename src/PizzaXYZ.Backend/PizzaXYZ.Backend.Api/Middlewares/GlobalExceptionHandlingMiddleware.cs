using PizzaXYZ.Backend.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace PizzaXYZ.Backend.Api.Middlewares;

public class ErrorResponse
{
    public string? Type { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
}

public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string message;
        string type;

        switch (exception)
        {
            case DomainException domainException:
                status = HttpStatusCode.UnprocessableEntity;
                message = domainException.Message;
                type = "Domain Error";
                break;
            case NotFoundException notFoundException:
                status = HttpStatusCode.NotFound;
                message = notFoundException.Message;
                type = "Not Found";
                break;
            case BadRequestException badRequestException:
                status = HttpStatusCode.BadRequest;
                message = badRequestException.Message;
                type = "Bad Request";
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                type = "Server Error";
                break;
        }

        var errorResponse = new ErrorResponse
        {
            Type = type,
            Message = message,
            StackTrace = exception.StackTrace
        };

        var result = JsonSerializer.Serialize(errorResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        logger.LogError(exception, $"An error occurred: {message}");

        await context.Response.WriteAsync(result);
    }
}