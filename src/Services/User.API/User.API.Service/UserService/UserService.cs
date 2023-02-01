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
        if (userData is not null) 
        {
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
        else 
            throw new UserException(CustomErrors.UserNotFound);
        
    }

    public Task<ServiceResponseModel<Data.Entities.User>> GetUserById(Guid userId)
    {
        throw new NotImplementedException();

        // TODO => Add queue to send Jira Integration
    }

    public Task<ServiceResponseModel<Data.Entities.User>> Update(UserModel userModel)
    {
        throw new NotImplementedException();

        // TODO => Add queue to send Jira Integration
    }
}