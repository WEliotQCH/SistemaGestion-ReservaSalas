using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservationById;

public class GetReservationByIdHandler
    : IRequestHandler<GetReservationByIdQuery, ReservationDto?>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationByIdHandler(
        IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ReservationDto?> Handle(
        GetReservationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var reservation =
            await _reservationRepository.GetByIdAsync(request.Id);

        if (reservation is null)
            return null;

        return new ReservationDto
        {
            Id = reservation.Id,
            UserId = reservation.UserId,
            RoomId = reservation.RoomId,
            Date = reservation.Date,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Reason = reservation.Reason,
            Status = reservation.Status,
            CreatedAt = reservation.CreatedAt
        };
    }
}