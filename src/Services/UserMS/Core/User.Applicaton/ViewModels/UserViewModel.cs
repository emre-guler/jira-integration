namespace User.Applicaton.ViewModels;

public class UserViewModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public required string AvatarUrl { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}