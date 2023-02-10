using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using User.Applicaton.Features.Commands.CreateUser;
using User.Applicaton.Features.Commands.DeleteUserById;
using User.Applicaton.Features.Queries.GetAllUsers;
using User.Applicaton.Features.Queries.GetUserById;
using User.Applicaton.Mapping;
using User.Applicaton.Middlewares;

namespace User.Applicaton;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(WebApplication app, IServiceCollection services)
    {
        // Exception Middleware
        app.UseMiddleware<ExceptionMiddleware>();

        // Mapster 
        TypeAdapterConfig mapConfig = MappingConfiguration.Generate();
        services.AddSingleton(mapConfig);
        services.AddSingleton<IMapper, ServiceMapper>();

        // MediatR
        Assembly assm = Assembly.GetExecutingAssembly();
        services.AddMediatR(assm);

        // FluentValidation
        services.AddTransient<IValidator<GetUserByIdQuery>, GetUserByIdQueryValidator>();
        services.AddTransient<IValidator<GetAllUsersQuery>, GetAllUsersQueryValidator>();

        services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddTransient<IValidator<DeleteUserByIdCommand>, DeleteUserByIdCommandValidator>();
    }
}