using MediatR;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.UpdateReservation;

public record UpdateReservationCommand(
    int Id,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string? Reason
) : IRequest<bool>;