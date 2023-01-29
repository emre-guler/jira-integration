using Microsoft.AspNetCore.Mvc;

namespace Project.API.Controllers;

[ApiController]
[Route("/api/projects/")]
public class ProjectController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("Project microservice is awake!");
    }
}
