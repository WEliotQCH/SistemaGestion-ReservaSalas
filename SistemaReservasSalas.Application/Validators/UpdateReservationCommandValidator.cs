using FluentValidation;
using SistemaReservasSalas.Application.Features.Reservations.Commands.UpdateReservation;

namespace SistemaReservasSalas.Application.Validators;

public class UpdateReservationCommandValidator
    : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("La hora fin debe ser mayor a la hora inicio.");
    }
}