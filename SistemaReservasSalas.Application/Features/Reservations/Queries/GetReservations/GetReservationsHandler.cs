using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservations;

public class GetReservationsHandler
    : IRequestHandler<GetReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationsHandler(
        IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDto>> Handle(
        GetReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllAsync();

        return reservations.Select(reservation => new ReservationDto
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
        }).ToList();
    }
}  