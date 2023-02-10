using MediatR;
using User.Applicaton.ViewModels;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Commands.DeleteUserById;

public record DeleteUserByIdCommand : IRequest<ServiceResponse<Guid>>
{
    public required Guid Id { get; init; }
}