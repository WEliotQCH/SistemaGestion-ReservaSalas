using MediatR;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.CreateSchedule;

public record CreateScheduleCommand(
    TimeOnly StartTime,
    TimeOnly EndTime
) : IRequest<int>;