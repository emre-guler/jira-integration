namespace User.API.Models;


public sealed record Response(string? ErrorDetail, object? Data = null, MetaData? MetaData = null)
{
    public bool HasError => !String.IsNullOrWhiteSpace(ErrorDetail);
}

public record MetaData(int Offset, int Limit, int Count){};