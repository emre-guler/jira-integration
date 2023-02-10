using MediatR;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Commands.CreateUser;

public record CreateUserCommand : IRequest<ServiceResponse<Guid>>
{
    public required string Name { get; init; }
    public required string Password { get; init; }
    public required string EmailAddress { get; init; }
    public string DisplayName => Name;
    public string? AvatarUrl { get; init; }
}
