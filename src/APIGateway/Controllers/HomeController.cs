using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("I'm awake!");
    }
}
