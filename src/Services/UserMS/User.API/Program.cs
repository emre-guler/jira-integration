var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence Registration
string connectionString = builder.Configuration.GetConnectionString("POSTGRESQL_CONNECTION") ?? "";
User.Persistence.ServiceRegistration.AddPersistenceRegistration(builder.Services, connectionString);

var app = builder.Build();

// Application Registration
User.Applicaton.ServiceRegistration.AddApplicationRegistration(app, builder.Services);

// API Registration
User.API.ServiceRegistration.AddAPIRegistration(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

