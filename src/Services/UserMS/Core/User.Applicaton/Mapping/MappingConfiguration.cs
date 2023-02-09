using FastExpressionCompiler;
using Mapster;

namespace User.Applicaton.Mapping;

public static class MappingConfiguration
{
    public static TypeAdapterConfig Generate()
    {
        var config = new TypeAdapterConfig();

        // Configurations here...

        config.Compiler = exp => exp.CompileFast();
        config.Compile();

        return config;
    }
}
