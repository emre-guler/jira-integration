namespace User.API;

public static class ServiceRegistration
{
    public static void AddAPIServiceRegistration(IServiceCollection services)
    {
        services.AddHealthChecks();
    }

    public static void AddAPIAppRegistration(WebApplication app)
    {
        app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
        {
            ResponseWriter = async (context, response) =>
            {
                await context.Response.WriteAsync("UserAPI OK");
            }
        });
    }
}

