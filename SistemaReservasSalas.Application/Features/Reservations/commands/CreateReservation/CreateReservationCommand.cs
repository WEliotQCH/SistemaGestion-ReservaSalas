using MediatR;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.CreateReservation;

public record CreateReservationCommand(
    int UserId,
    int RoomId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string? Reason
) : IRequest<int>;