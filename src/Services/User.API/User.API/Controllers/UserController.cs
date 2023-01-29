using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers;

[ApiController]
[Route("/api/users/")]
public class UserController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("User microservice is awake!");
    }
}
