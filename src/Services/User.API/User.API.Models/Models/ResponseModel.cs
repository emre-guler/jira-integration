namespace User.API.Models;


public sealed record Response(string errorDetail, object? data = null, MetaData? metaData = null)
{
    public bool HasError => errorDetail.Any();
    public string? ErrorDetail => errorDetail;
    public object? Data => data;
    public MetaData? MetaData => metaData;
}

public record MetaData(int Offset, int Limit, int Count){};