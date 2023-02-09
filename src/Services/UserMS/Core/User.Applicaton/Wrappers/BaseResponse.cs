namespace User.Applicaton.Wrappers;

public class BaseResponse
{
    public BaseResponse(string message, bool isSuccess = false)
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public Guid Id => Guid.NewGuid();
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}