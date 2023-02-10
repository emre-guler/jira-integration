namespace User.Applicaton.Wrappers;

public class ValidationResponse<T> : BaseResponse
{
    public ValidationResponse(T value)
    {
        ValidationErrors = value;
    }

    public T ValidationErrors { get; set; }
}

public record ValidatonError(string Code, string Description);