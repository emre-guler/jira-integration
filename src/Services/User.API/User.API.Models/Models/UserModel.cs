namespace User.API.Models;

public sealed record UserModel(string name, string password, string emailAddress, string displayName, string avatarUrl)
{
    public string Name => name;
    public string Password => password;
    public string EmailAddress => emailAddress;
    public string DisplayName => displayName;
    public string AvatarUrl => avatarUrl;
}