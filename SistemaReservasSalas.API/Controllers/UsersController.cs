using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.Users.Commands.RegisterUser;
using SistemaReservasSalas.Application.Features.Users.Queries.GetUsers;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(
        RegisterUserCommand command)
    {
        var userId =
            await _mediator.Send(command);

        return Created(
            string.Empty,
            new
            {
                Id = userId
            });
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users =
            await _mediator.Send(
                new GetUsersQuery());

        return Ok(users);
    }
}