namespace User.Applicaton.Wrappers;

public class ServiceResponse<T> : BaseResponse
{
    public ServiceResponse(string message) : base(message)
    {

    }
    public required T Value { get; set; }
}