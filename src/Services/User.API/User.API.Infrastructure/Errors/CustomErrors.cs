using User.API.Models;

namespace User.API.Infrastructure.Errors;

public static class CustomErrors
{
    public static Response SomethingWentWrong = new("Something went wrong!");
    public static Response MailExist = new("E-Mail address already exist!");
    public static Response UserNotFound = new("User not found!");
}