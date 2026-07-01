using MediatR;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.CreateSchedule;

public class CreateScheduleHandler
    : IRequestHandler<CreateScheduleCommand, int>
{
    private readonly IScheduleRepository _scheduleRepository;

    public CreateScheduleHandler(
        IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<int> Handle(
        CreateScheduleCommand request,
        CancellationToken cancellationToken)
    {
        var schedule = new Schedule(
            request.StartTime,
            request.EndTime);

        await _scheduleRepository.AddAsync(schedule);

        return schedule.Id;
    }
}