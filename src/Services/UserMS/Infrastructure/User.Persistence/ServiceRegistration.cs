using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Applicaton.Intefaces.Repositories;
using User.Persistence.Context;
using User.Persistence.Repositories;

namespace User.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString)
        );

        services.AddTransient<IUserRepository, UserRepository>();
    }
}

