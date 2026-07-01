using MediatR;
using SistemaReservasSalas.Domain.Exceptions;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.UpdateReservation;

public class UpdateReservationHandler
    : IRequestHandler<UpdateReservationCommand, bool>
{
    private readonly IReservationRepository _reservationRepository;

    public UpdateReservationHandler(
        IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<bool> Handle(
        UpdateReservationCommand request,
        CancellationToken cancellationToken)
    {
        var reservation =
            await _reservationRepository.GetByIdAsync(request.Id);

        if (reservation is null)
            return false;

        var existsConflict =
            await _reservationRepository.ExistsConflictAsync(
                reservation.RoomId,
                request.Date,
                request.StartTime,
                request.EndTime);

        if (existsConflict)
            throw new ReservationConflictException();

        reservation.Update(
            request.Date,
            request.StartTime,
            request.EndTime,
            request.Reason);

        await _reservationRepository.UpdateAsync(reservation);

        return true;
    }
}