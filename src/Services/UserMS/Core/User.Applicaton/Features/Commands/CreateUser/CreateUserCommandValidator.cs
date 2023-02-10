using FluentValidation;
using User.Applicaton.Extensions;

namespace User.Applicaton.Features.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .WithError("name_must_min", "Name must be longer than 3 characters.")
            .MaximumLength(100)
            .WithError("name_must_max", "Name must be shorter than 100 characters.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")
            .WithError("passowrd_not_valid", "Password must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters.");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .EmailAddress()
            .WithError("email_not_valid", "Invalid mail address.");

        RuleFor(x => x.AvatarUrl)
            .Matches(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+(?:png|jpg|jpeg)+$")
            .WithError("avatar_not_valid", "Image URL is not valid.");
    }
}

