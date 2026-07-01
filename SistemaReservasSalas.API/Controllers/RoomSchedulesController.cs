using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.RoomSchedules.Commands.AssignScheduleToRoom;
using SistemaReservasSalas.Application.Features.RoomSchedules.Commands.RemoveScheduleFromRoom;
using SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetRoomsBySchedule;
using SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetSchedulesByRoom;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoomSchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomSchedulesController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AssignSchedule(
        AssignScheduleToRoomCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result)
            return BadRequest();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveSchedule(
        [FromBody] RemoveScheduleFromRoomCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpGet("room/{roomId:int}")]
    public async Task<IActionResult> GetSchedulesByRoom(
        int roomId)
    {
        var schedules = await _mediator.Send(
            new GetSchedulesByRoomQuery(roomId));

        return Ok(schedules);
    }

    [HttpGet("schedule/{scheduleId:int}")]
    public async Task<IActionResult> GetRoomsBySchedule(
        int scheduleId)
    {
        var rooms = await _mediator.Send(
            new GetRoomsByScheduleQuery(scheduleId));

        return Ok(rooms);
    }
}