using User.API.Models;

namespace User.API.Service.UserService;

public interface IUserService
{
    Task<Data.Entities.User> GetUserById(Guid userId);
    Task<Data.Entities.User> Create(UserModel userModel);
    Task<Data.Entities.User> Update(UserModel userModel);
    Task<Data.Entities.User> DeleteById(Guid userId);
}