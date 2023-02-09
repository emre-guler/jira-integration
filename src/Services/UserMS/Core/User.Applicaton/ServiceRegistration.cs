using Microsoft.AspNetCore.Builder;
using User.Applicaton.Middlewares;

namespace User.Applicaton;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}