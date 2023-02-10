using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Applicaton.Features.Commands.CreateUser;
using User.Applicaton.Features.Commands.DeleteUserById;
using User.Applicaton.Features.Queries.GetAllUsers;
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

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromBody] GetAllUsersQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{userId:Gudi}")]
    public async Task<IActionResult> DeleteUserById([FromBody] DeleteUserByIdCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}