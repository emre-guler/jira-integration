using Microsoft.AspNetCore.Mvc;
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
}
