using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using User.Applicaton.Mapping;
using User.Applicaton.Middlewares;

namespace User.Applicaton;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this WebApplication app, IServiceCollection services)
    {
        // Exception Middleware
        app.UseMiddleware<ExceptionMiddleware>();

        // Mapster 
        TypeAdapterConfig mapConfig = MappingConfiguration.Generate();
        services.AddSingleton(mapConfig);
        services.AddSingleton<IMapper, ServiceMapper>();
    }
}