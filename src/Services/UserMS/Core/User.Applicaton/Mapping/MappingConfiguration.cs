using FastExpressionCompiler;
using Mapster;
using User.Applicaton.Features.Queries.GetUserById;

namespace User.Applicaton.Mapping;

public static class MappingConfiguration
{
    public static TypeAdapterConfig Generate()
    {
        var config = new TypeAdapterConfig();

        // Configurations here...
        config.NewConfig<GetUserByIdViewModel, Domain.Entities.User>();

        config.Compiler = exp => exp.CompileFast();
        config.Compile();

        return config;
    }
}
