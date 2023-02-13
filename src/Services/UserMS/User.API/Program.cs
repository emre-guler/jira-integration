using FluentValidation.AspNetCore;
using System.Text.Json;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using User.Applicaton.Wrappers;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => JsonSerializer.Deserialize<ValidatonError>(e.ErrorMessage))
                .ToList();

            return new BadRequestObjectResult(new ValidationResponse<List<ValidatonError?>>(errors));
        };
    })
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

#pragma warning restore CS0618 // Type or member is obsolete
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence Service Registration
string connectionString = builder.Configuration.GetConnectionString("POSTGRESQL_CONNECTION") ?? "";
User.Persistence.ServiceRegistration.AddPersistenceServiceRegistration(builder.Services, connectionString);

// Application Service Registration
User.Applicaton.ServiceRegistration.AddApplicatonServiceRegistration(builder.Services);

// API Service Registration
User.API.ServiceRegistration.AddAPIServiceRegistration(builder.Services);

var app = builder.Build();

// Persistence App Registration
User.Persistence.ServiceRegistration.AddPersistenceAppRegistration(app);

// Application App Registration
User.Applicaton.ServiceRegistration.AddApplicationAppRegistration(app);

// API App Registration
User.API.ServiceRegistration.AddAPIAppRegistration(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

