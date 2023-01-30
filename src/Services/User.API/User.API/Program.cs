using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using User.API.Data.Context;
using User.API.Infrastructure.Middlewares;
using User.API.Service.MapperService;
using User.API.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("POSTGRESQL_CONNECTION") ?? "";
builder.Services.AddDbContextPool<UserContext>(options => 
{
    options.UseNpgsql(connectionString);
});

var config = MapperConfiguration.Generate();

builder.Services.AddSingleton(config);
builder.Services.AddSingleton<IMapper, ServiceMapper>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
