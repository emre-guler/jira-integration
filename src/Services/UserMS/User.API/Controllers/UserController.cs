using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Applicaton.Features.Queries.GetUserById;

namespace User.API.Controllers;

[ApiController]
[Route("/api/users/")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId:Guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] GetUserByIdQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
}