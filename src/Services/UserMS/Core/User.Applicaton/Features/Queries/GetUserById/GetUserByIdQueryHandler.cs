using MapsterMapper;
using MediatR;
using User.Applicaton.Exceptions;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<GetUserByIdViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetUserByIdViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.User? userData = await _userRepository.GetById(request.Id);
        if (userData is null)
            throw new UserException(CustomErrors.UserNotFound);
        GetUserByIdViewModel userViewModel = _mapper.Map<GetUserByIdViewModel>(userData);

        return new ServiceResponse<GetUserByIdViewModel>(userViewModel);
    }
}