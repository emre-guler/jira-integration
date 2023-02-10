using MapsterMapper;
using MediatR;
using User.Applicaton.Exceptions;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isMailExist = await _userRepository.IsMailExist(request.EmailAddress);
        if (isMailExist)
            throw new UserException(CustomErrors.MailExist);
        Domain.Entities.User newUserData =  _mapper.Map<Domain.Entities.User>(request);
        Domain.Entities.User newUser = await _userRepository.Add(newUserData);

        return new ServiceResponse<Guid>(newUser.Id);
    }
}

