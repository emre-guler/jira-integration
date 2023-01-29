using User.API.Models;

namespace User.API.Infrastructure.Errors;

public static class CustomErrors 
{
    public static Response SomethingWentWrong = new("Something went wrong!");
}