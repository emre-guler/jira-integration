using MapsterMapper;
using MediatR;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.ViewModels;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<List<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.User> userList = await _userRepository.GetAll(request.PageSize, request.PageSize);
        List<UserViewModel> userListViewModel = _mapper.Map<List<UserViewModel>>(userList);

        return new PagedResponse<List<UserViewModel>>(userListViewModel, request.PageSize, request.PageNumber);
    }
}