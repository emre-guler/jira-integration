using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers;

[ApiController]
[Route("/api/")]
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("User microservice is awake!");
    }
}
