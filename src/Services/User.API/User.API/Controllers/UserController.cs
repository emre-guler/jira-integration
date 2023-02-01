using Microsoft.AspNetCore.Mvc;
using User.API.Infrastructure.Errors;
using User.API.Models;
using User.API.Service.UserService;

namespace User.API.Controllers;

[ApiController]
[Route("/api/users/")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserModel userModel)
    {
        if (!ModelState.IsValid) return BadRequest(new Models.Response(
            string.Join("\r\n",ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList())
        ));

        ServiceResponseModel<Data.Entities.User> userData = await _userService.Create(userModel);
        if (!userData.HasError)
            throw new UserException(CustomErrors.SomethingWentWrong);

        return Ok(new Models.Response(null, userData.Entity));
    }

    // TODO => JWT Control
    [HttpDelete("{userId:Guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
    {
        if (userId == default(Guid))
            return BadRequest(new Models.Response("BadRequest", null, null));

        ServiceResponseModel<Data.Entities.User> userData = await _userService.DeleteById(userId);
        if (userData.HasError) 
            throw new UserException(CustomErrors.SomethingWentWrong);
        
        return Ok(new Models.Response(null, "success"));
    }
}
