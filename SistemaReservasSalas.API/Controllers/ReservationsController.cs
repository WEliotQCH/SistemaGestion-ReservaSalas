using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasSalas.Application.Features.Reservations.Commands.CancelReservation;
using SistemaReservasSalas.Application.Features.Reservations.Commands.CreateReservation;
using SistemaReservasSalas.Application.Features.Reservations.Commands.UpdateReservation;
using SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservationById;
using SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservations;
using SistemaReservasSalas.Application.Features.Reservations.Queries.GetRoomAvailability;

namespace SistemaReservasSalas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateReservationCommand command)
    {
        var reservationId =
            await _mediator.Send(command);

        return Created(
            string.Empty,
            new
            {
                Id = reservationId
            });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateReservationCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result =
            await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Cancel(
        int id)
    {
        var result =
            await _mediator.Send(
                new CancelReservationCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservations =
            await _mediator.Send(
                new GetReservationsQuery());

        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var reservation =
            await _mediator.Send(
                new GetReservationByIdQuery(id));

        if (reservation is null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpGet("availability")]
    public async Task<IActionResult> GetAvailability(
        [FromQuery] int roomId,
        [FromQuery] DateOnly date,
        [FromQuery] TimeOnly startTime,
        [FromQuery] TimeOnly endTime)
    {
        var available =
            await _mediator.Send(
                new GetRoomAvailabilityQuery(
                    roomId,
                    date,
                    startTime,
                    endTime));

        return Ok(new
        {
            Available = available
        });
    }
}