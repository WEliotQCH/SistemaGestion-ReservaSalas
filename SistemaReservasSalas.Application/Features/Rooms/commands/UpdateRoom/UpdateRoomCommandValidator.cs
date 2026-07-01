using FluentValidation;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandValidator
    : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Location)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Capacity)
            .GreaterThan(0);

        RuleFor(x => x.Description)
            .MaximumLength(500);
    }
}