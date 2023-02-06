using System;

namespace APIGateway.CustomConfigurations;

public static class HealthCheckConfiguration
{
    public static void Use(WebApplication app)
    {
        app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
        {
            ResponseWriter = async (context, response) =>
            {
                await context.Response.WriteAsync("APIGateway OK");
            }
        });
    }
}