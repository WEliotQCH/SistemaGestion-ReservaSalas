using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Schedules.Queries.GetScheduleById;

public class GetScheduleByIdHandler
    : IRequestHandler<GetScheduleByIdQuery, ScheduleDto?>
{
    private readonly IScheduleRepository _scheduleRepository;

    public GetScheduleByIdHandler(
        IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<ScheduleDto?> Handle(
        GetScheduleByIdQuery request,
        CancellationToken cancellationToken)
    {
        var schedule =
            await _scheduleRepository.GetByIdAsync(request.Id);

        if (schedule is null)
            return null;

        return new ScheduleDto
        {
            Id = schedule.Id,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime
        };
    }
}