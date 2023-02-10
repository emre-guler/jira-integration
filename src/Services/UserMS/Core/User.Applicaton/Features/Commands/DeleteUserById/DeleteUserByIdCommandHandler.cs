using MapsterMapper;
using MediatR;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, ServiceResponse<Guid>>
{
    private readonly IUserRepository _userRepository;
    public DeleteUserByIdCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
    }

    public async Task<ServiceResponse<Guid>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        Guid deletedUserId = await _userRepository.Delete(request.Id);

        return new ServiceResponse<Guid>(deletedUserId);
    }
}
