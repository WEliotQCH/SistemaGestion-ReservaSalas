using FluentValidation;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.DeactivateRoom;

public class DeactivateRoomCommandValidator
    : AbstractValidator<DeactivateRoomCommand>
{
    public DeactivateRoomCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}