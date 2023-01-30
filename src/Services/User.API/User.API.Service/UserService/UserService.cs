using MapsterMapper;
using User.API.Models;

namespace User.API.Service.UserService;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<Data.Entities.User> GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Data.Entities.User> Create(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public Task<Data.Entities.User> Update(UserModel userModel)
    {
        throw new NotImplementedException();
    }
    public Task<Data.Entities.User> DeleteById(Guid userId)
    {
        throw new NotImplementedException();
    }
}