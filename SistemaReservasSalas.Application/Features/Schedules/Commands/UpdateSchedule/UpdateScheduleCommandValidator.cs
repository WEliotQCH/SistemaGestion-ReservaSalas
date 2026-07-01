using FluentValidation;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.UpdateSchedule;

public class UpdateScheduleCommandValidator
    : AbstractValidator<UpdateScheduleCommand>
{
    public UpdateScheduleCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.StartTime)
            .NotEmpty();

        RuleFor(x => x.EndTime)
            .NotEmpty();

        RuleFor(x => x)
            .Must(x => x.EndTime > x.StartTime)
            .WithMessage(
                "La hora de fin debe ser mayor que la hora de inicio.");
    }
}