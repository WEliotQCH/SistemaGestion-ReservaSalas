using MediatR;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetRoomAvailability;

public record GetRoomAvailabilityQuery(
    int RoomId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime
) : IRequest<bool>;