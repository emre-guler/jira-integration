using Microsoft.AspNetCore.Http;
using User.API.Infrastructure.Errors;
using User.API.Models;

namespace User.API.Infrastructure.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try 
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            Response errorResponse;
            HttpResponse response = context.Response;

            switch (exception) 
            {
                case UserException userEx:
                    errorResponse = userEx.Response;
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    errorResponse = CustomErrors.SomethingWentWrong;
                    response.StatusCode = (int) StatusCodes.Status500InternalServerError;
                    break;
            }

            await response.WriteAsJsonAsync(errorResponse);
        }
    }
}