namespace User.API.Data.Entities;

public class User : BaseEntity
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string EmailAddress { get; set; }
    public string DisplayName => Name;
    public string? AvatarUrl 
    {
        get { return this.AvatarUrl; }
        set { this.AvatarUrl =  String.IsNullOrWhiteSpace(this.AvatarUrl) ? "shorturl.at/GRUVY" : this.AvatarUrl; }
    }
    public bool IsActive { get; set; }
    public bool IsSendJira { get; set; }
}