using APIGateway.CustomConfigurations;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Services
builder.Services.AddHealthChecks();
OcelotConfiguration.Configure(builder);


var app = builder.Build();

// Custom App
await app.UseOcelot();
HealthCheckConfiguration.Use(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
