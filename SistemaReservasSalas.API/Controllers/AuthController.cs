using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.Auth.Commands.Login;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginCommand command)
    {
        var response =
            await _mediator.Send(command);

        if (response is null)
        {
            return Unauthorized(
                new
                {
                    Message = "Invalid credentials."
                });
        }

        return Ok(response);
    }
}