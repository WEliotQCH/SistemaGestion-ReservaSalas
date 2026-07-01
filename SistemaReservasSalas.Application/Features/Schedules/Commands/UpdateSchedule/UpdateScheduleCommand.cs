using MediatR;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.UpdateSchedule;

public record UpdateScheduleCommand(
    int Id,
    TimeOnly StartTime,
    TimeOnly EndTime
) : IRequest<bool>;