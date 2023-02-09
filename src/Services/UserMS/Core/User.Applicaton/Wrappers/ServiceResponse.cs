namespace User.Applicaton.Wrappers;

public class ServiceResponse<T> : BaseResponse
{
    public ServiceResponse(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
}