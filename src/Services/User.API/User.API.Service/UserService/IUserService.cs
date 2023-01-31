using User.API.Models;

namespace User.API.Service.UserService;

public interface IUserService
{
    Task<ServiceResponseModel<Data.Entities.User>> GetUserById(Guid userId);
    Task<ServiceResponseModel<Data.Entities.User>> Create(UserModel userModel);
    Task<ServiceResponseModel<Data.Entities.User>> Update(UserModel userModel);
    Task<ServiceResponseModel<Data.Entities.User>> DeleteById(Guid userId);
}