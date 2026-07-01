using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Schedules.Queries.GetSchedules;

public class GetSchedulesHandler
    : IRequestHandler<GetSchedulesQuery, List<ScheduleDto>>
{
    private readonly IScheduleRepository _scheduleRepository;

    public GetSchedulesHandler(
        IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<List<ScheduleDto>> Handle(
        GetSchedulesQuery request,
        CancellationToken cancellationToken)
    {
        var schedules =
            await _scheduleRepository.GetAllAsync();

        return schedules.Select(schedule => new ScheduleDto
        {
            Id = schedule.Id,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime
        }).ToList();
    }
}