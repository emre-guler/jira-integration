using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using User.API.Data.Context;
using User.API.Infrastructure.Errors;
using User.API.Models;

namespace User.API.Service.UserService;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserContext _userContext;
    public UserService(IMapper mapper, UserContext userContext)
    {
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<ServiceResponseModel<Data.Entities.User>> Create(UserModel userModel)
    {
        if (await _userContext.Users.AnyAsync(x => x.Equals(userModel.EmailAddress)))
            throw new UserException(CustomErrors.MailExist);

        Data.Entities.User newUser = _mapper.Map<Data.Entities.User>(userModel);

        newUser.CreatedAt = DateTime.UtcNow;
        newUser.UpdatedAt = DateTime.UtcNow;

        await _userContext.Users.AddAsync(newUser);
        int saveResponse = await _userContext.SaveChangesAsync();

        return new ServiceResponseModel<Data.Entities.User>()
        {
            Entity = newUser,
            HasError = saveResponse == 0
        };
    }

    public Task<ServiceResponseModel<Data.Entities.User>> DeleteById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponseModel<Data.Entities.User>> GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponseModel<Data.Entities.User>> Update(UserModel userModel)
    {
        throw new NotImplementedException();
    }
}