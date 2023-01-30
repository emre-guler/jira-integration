using FastExpressionCompiler;
using Mapster;

namespace User.API.Service.MapperService;

public static class MapperConfiguration 
{
    public static TypeAdapterConfig Generate() 
    {
        TypeAdapterConfig config = new TypeAdapterConfig();

        config.NewConfig<Models.UserModel, Data.Entities.User>();

        config.Compiler = exp => exp.CompileFast();
        config.Compile();

        return config;
    }
}