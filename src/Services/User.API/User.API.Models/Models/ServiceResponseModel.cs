namespace User.API.Models;

public record ServiceResponseModel<T>
{
    public bool HasError { get; set; }
    public T? Entity { get; set; }
}