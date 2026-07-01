using FluentValidation;
using SistemaReservasSalas.Application.Features.Reservations.Commands.CancelReservation;

namespace SistemaReservasSalas.Application.Validators;

public class CancelReservationCommandValidator
    : AbstractValidator<CancelReservationCommand>
{
    public CancelReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("El Id de la reserva debe ser mayor a cero.");
    }
}