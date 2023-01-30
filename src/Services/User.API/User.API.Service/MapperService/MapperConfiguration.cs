using Mapster;

namespace User.API.Service.MapperService;

public static class MapperConfiguration 
{
    public static TypeAdapterConfig Generate() 
    {
        TypeAdapterConfig config = new TypeAdapterConfig();

        config.NewConfig<Models.UserModel, Data.Entities.User>();

        config.Compile();

        return config;
    }
}