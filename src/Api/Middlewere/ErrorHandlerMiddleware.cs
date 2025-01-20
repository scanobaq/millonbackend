using System.Text.Json;
using Domain.Exceptions.Property;

namespace Api.Middlewere;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        switch (exception)
        {
            case PropertyNotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case InvalidPropertyException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case PropertyCreateException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case PropertyFilterException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        var result = JsonSerializer.Serialize(new
        {
            error = exception.Message,
            statusCode = context.Response.StatusCode
        });

        return context.Response.WriteAsync(result);
    }

}
