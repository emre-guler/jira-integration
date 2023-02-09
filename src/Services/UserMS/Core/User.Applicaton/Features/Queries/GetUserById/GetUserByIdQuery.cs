using MediatR;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ServiceResponse<GetUserByIdViewModel>>
{
    public required Guid Id { get; set; }
}