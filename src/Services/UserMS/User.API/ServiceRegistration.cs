namespace User.API;

public static class ServiceRegistration
{
    public static void AddAPIRegistration(WebApplication app)
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

