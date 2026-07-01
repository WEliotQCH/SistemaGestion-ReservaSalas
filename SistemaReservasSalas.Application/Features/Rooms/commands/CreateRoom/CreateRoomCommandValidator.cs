using FluentValidation;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomCommandValidator
    : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
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