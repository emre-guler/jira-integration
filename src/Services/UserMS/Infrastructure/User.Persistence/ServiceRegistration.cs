using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Persistence.Context;

namespace User.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString)
        );
    }
}

