using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers;

[ApiController]
[Route("api/")]
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("I'm awake!");
    }
}
