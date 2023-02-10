using MediatR;
using User.Applicaton.ViewModels;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<PagedResponse<List<UserViewModel>>>
{
    public required int PageSize { get; init; }
    public required int PageNumber { get; init; }
}