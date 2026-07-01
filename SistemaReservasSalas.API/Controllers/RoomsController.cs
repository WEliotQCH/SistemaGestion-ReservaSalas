using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.Rooms.Commands.CreateRoom;
using SistemaReservasSalas.Application.Features.Rooms.Commands.DeactivateRoom;
using SistemaReservasSalas.Application.Features.Rooms.Commands.UpdateRoom;
using SistemaReservasSalas.Application.Features.Rooms.Queries.GetRoomById;
using SistemaReservasSalas.Application.Features.Rooms.Queries.GetRooms;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms =
            await _mediator.Send(new GetRoomsQuery());

        return Ok(rooms);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var room =
            await _mediator.Send(
                new GetRoomByIdQuery(id));

        if (room is null)
            return NotFound();

        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateRoomCommand command)
    {
        var id =
            await _mediator.Send(command);

        return Created(
            string.Empty,
            new { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateRoomCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var updated =
            await _mediator.Send(command);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(
        int id)
    {
        var deactivated =
            await _mediator.Send(
                new DeactivateRoomCommand(id));

        if (!deactivated)
            return NotFound();

        return NoContent();
    }
}