using User.Applicaton.Wrappers;

namespace User.Applicaton.Exceptions;

public class UserException : Exception
{
    public UserException(BaseResponse baseResponse) : base(baseResponse.Message)
    {
        BaseResponse = baseResponse;
    }

    public BaseResponse BaseResponse { get; set; }
}

public static class CustomErrors
{
    public static BaseResponse SomethingWentWrong = new("Something went wrong!");
    public static BaseResponse MailExist = new("E-Mail address already exist!");
    public static BaseResponse UserNotFound = new("User not found!");
}