using FluentValidation;
using SistemaReservasSalas.Application.Features.Reservations.Commands.CreateReservation;

namespace SistemaReservasSalas.Application.Validators;

public class CreateReservationCommandValidator
    : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0);

        RuleFor(x => x.RoomId)
            .GreaterThan(0);

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("La hora fin debe ser mayor a la hora inicio.");
    }
}