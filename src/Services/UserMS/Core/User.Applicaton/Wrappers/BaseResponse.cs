namespace User.Applicaton.Wrappers;

public class BaseResponse
{
    public BaseResponse()
    {

    }

    public BaseResponse(string message)
    {
        Message = message;
    }

    public Guid Id => Guid.NewGuid();
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}