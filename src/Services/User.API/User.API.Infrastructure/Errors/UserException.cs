using User.API.Models;

namespace User.API.Infrastructure.Errors;

public class UserException : Exception 
{
    public UserException(Response response) : base(response.ErrorDetail)
    {
        Response = response;
    }

    public Response Response { get; set; }
}