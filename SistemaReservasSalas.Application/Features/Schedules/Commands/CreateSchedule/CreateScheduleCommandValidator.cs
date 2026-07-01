using FluentValidation;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommandValidator
    : AbstractValidator<CreateScheduleCommand>
{
    public CreateScheduleCommandValidator()
    {
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