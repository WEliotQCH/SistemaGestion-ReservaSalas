using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.Schedules.Commands.CreateSchedule;
using SistemaReservasSalas.Application.Features.Schedules.Commands.UpdateSchedule;
using SistemaReservasSalas.Application.Features.Schedules.Queries.GetScheduleById;
using SistemaReservasSalas.Application.Features.Schedules.Queries.GetSchedules;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchedulesController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var schedules =
            await _mediator.Send(
                new GetSchedulesQuery());

        return Ok(schedules);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var schedule =
            await _mediator.Send(
                new GetScheduleByIdQuery(id));

        if (schedule is null)
            return NotFound();

        return Ok(schedule);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateScheduleCommand command)
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
        UpdateScheduleCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var updated =
            await _mediator.Send(command);

        if (!updated)
            return NotFound();

        return NoContent();
    }
}