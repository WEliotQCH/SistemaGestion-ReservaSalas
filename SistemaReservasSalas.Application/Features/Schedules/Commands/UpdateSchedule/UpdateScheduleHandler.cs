using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Schedules.Commands.UpdateSchedule;

public class UpdateScheduleHandler
    : IRequestHandler<UpdateScheduleCommand, bool>
{
    private readonly IScheduleRepository _scheduleRepository;

    public UpdateScheduleHandler(
        IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<bool> Handle(
        UpdateScheduleCommand request,
        CancellationToken cancellationToken)
    {
        var schedule =
            await _scheduleRepository.GetByIdAsync(request.Id);

        if (schedule is null)
            return false;

        schedule.Update(
            request.StartTime,
            request.EndTime);

        await _scheduleRepository.UpdateAsync(schedule);

        return true;
    }
}