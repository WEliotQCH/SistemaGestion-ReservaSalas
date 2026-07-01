using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetRoomAvailability;

public class GetRoomAvailabilityHandler
    : IRequestHandler<GetRoomAvailabilityQuery, bool>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IReservationRepository _reservationRepository;

    public GetRoomAvailabilityHandler(
        IRoomRepository roomRepository,
        IReservationRepository reservationRepository)
    {
        _roomRepository = roomRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<bool> Handle(
        GetRoomAvailabilityQuery request,
        CancellationToken cancellationToken)
    {
        var room =
            await _roomRepository.GetByIdAsync(request.RoomId);

        if (room is null)
            return false;

        var existsConflict =
            await _reservationRepository.ExistsConflictAsync(
                request.RoomId,
                request.Date,
                request.StartTime,
                request.EndTime);

        return !existsConflict;
    }
}