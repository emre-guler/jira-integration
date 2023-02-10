using FastExpressionCompiler;
using Mapster;
using User.Applicaton.Features.Queries.GetUserById;
using User.Applicaton.ViewModels;

namespace User.Applicaton.Mapping;

public static class MappingConfiguration
{
    public static TypeAdapterConfig Generate()
    {
        var config = new TypeAdapterConfig();

        // Configurations here...
        config.NewConfig<UserViewModel, Domain.Entities.User>();

        config.Compiler = exp => exp.CompileFast();
        config.Compile();

        return config;
    }
}
