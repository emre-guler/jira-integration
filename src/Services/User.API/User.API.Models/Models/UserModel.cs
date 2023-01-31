using System.ComponentModel.DataAnnotations;

namespace User.API.Models;

public sealed record UserModel(string name, string password, string emailAddress, string displayName, string avatarUrl)
{
    [Required]
    [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 3)]
    public string Name => name;

    [Required]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
    ErrorMessage = "{0} must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters.")]
    public string Password => password;
    
    [Required]
    [EmailAddress(ErrorMessage = "Invalid mail address.")]
    public string EmailAddress => emailAddress;
    
    [Required]
    [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 3)]
    public string DisplayName => displayName;
    
    [Required]
    [Url(ErrorMessage = "Invalid image URL.")]
    public string AvatarUrl => avatarUrl;
}