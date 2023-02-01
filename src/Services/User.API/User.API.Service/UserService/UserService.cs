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
        newUser.IsActive = true;

        await _userContext.Users.AddAsync(newUser);
        int saveResponse = await _userContext.SaveChangesAsync();

        return new ServiceResponseModel<Data.Entities.User>()
        {
            Entity = newUser,
            HasError = saveResponse == 0
        };

        // TODO => Add queue to send Jira Integration if saveResponse > 1
    }

    public async Task<ServiceResponseModel<Data.Entities.User>> DeleteById(Guid userId)
    {
        Data.Entities.User? userData = await _userContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (userData is null)
            throw new UserException(CustomErrors.UserNotFound);

        userData.DeletedAt = DateTime.UtcNow;
        userData.IsActive = false;

        int saveResponse = await _userContext.SaveChangesAsync();

        return new ServiceResponseModel<Data.Entities.User>()
        {
            HasError = saveResponse == 0,
            Entity = userData
        };

        // TODO => Add queue to send Jira Integration if saveResponse > 1
    }

    public async Task<ServiceResponseModel<Data.Entities.User>> GetUserById(Guid userId)
    {
        Data.Entities.User? userData = await _userContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (userData is null)
            throw new UserException(CustomErrors.UserNotFound);

        return new ServiceResponseModel<Data.Entities.User>()
        {
            HasError = false,
            Entity = userData
        };
    }

    public async Task<ServiceResponseModel<Data.Entities.User>> Update(UserModel userModel, Guid userId)
    {
        Data.Entities.User? userData = await _userContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (userData is null)
            throw new UserException(CustomErrors.UserNotFound);

        Data.Entities.User updatedUser = _mapper.Map<Data.Entities.User>(userModel);
        
        updatedUser.UpdatedAt = DateTime.UtcNow;
        
        int saveRespons = await _userContext.SaveChangesAsync();

        return new ServiceResponseModel<Data.Entities.User>() 
        {
            HasError = saveRespons == 0,
            Entity = updatedUser
        };

        // TODO => Add queue to send Jira Integration
    }
}