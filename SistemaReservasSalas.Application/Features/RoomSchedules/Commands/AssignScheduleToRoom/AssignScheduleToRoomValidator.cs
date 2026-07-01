using FluentValidation;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Commands.AssignScheduleToRoom;

public class AssignScheduleToRoomValidator
    : AbstractValidator<AssignScheduleToRoomCommand>
{
    public AssignScheduleToRoomValidator()
    {
        RuleFor(x => x.RoomId)
            .GreaterThan(0);

        RuleFor(x => x.ScheduleId)
            .GreaterThan(0);
    }
}