using Ocelot.DependencyInjection;

namespace APIGateway.CustomConfigurations;

public static class OcelotConfiguration 
{
    public static void Configure(WebApplicationBuilder builder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("ocelot.json")
            .Build();
        builder.Services.AddOcelot(configuration);
    }
}