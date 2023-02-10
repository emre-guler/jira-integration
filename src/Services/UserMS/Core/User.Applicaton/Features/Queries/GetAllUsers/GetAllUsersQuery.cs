using MediatR;
using User.Applicaton.ViewModels;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<PagedResponse<List<UserViewModel>>>
{
    public required int PageSize { get; set; }
    public required int PageNumber { get; set; }
}