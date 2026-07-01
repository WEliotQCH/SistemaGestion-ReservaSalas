using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.CancelReservation;

public class CancelReservationHandler
    : IRequestHandler<CancelReservationCommand, bool>
{
    private readonly IReservationRepository _reservationRepository;

    public CancelReservationHandler(
        IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<bool> Handle(
        CancelReservationCommand request,
        CancellationToken cancellationToken)
    {
        var reservation =
            await _reservationRepository.GetByIdAsync(request.Id);

        if (reservation is null)
            return false;

        reservation.Cancel();

        await _reservationRepository.UpdateAsync(reservation);

        return true;
    }
}