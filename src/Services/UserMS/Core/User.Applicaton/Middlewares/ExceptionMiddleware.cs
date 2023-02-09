using System;
using Microsoft.AspNetCore.Http;
using User.Applicaton.Exceptions;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Middlewares;

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
            BaseResponse errorResponse;
            HttpResponse response = context.Response;

            switch (exception)
            {
                case UserException userEx:
                    errorResponse = userEx.BaseResponse;
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    errorResponse = CustomErrors.SomethingWentWrong;
                    response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                    break;
            }

            await response.WriteAsJsonAsync(errorResponse);
        }
    }
}
