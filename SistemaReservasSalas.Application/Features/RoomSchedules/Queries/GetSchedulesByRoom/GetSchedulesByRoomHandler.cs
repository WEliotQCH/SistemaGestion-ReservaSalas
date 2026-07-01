using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetSchedulesByRoom;

public class GetSchedulesByRoomHandler
    : IRequestHandler<GetSchedulesByRoomQuery, List<ScheduleDto>>
{
    private readonly IRoomScheduleRepository _roomScheduleRepository;

    public GetSchedulesByRoomHandler(
        IRoomScheduleRepository roomScheduleRepository)
    {
        _roomScheduleRepository = roomScheduleRepository;
    }

    public async Task<List<ScheduleDto>> Handle(
        GetSchedulesByRoomQuery request,
        CancellationToken cancellationToken)
    {
        var schedules =
            await _roomScheduleRepository.GetSchedulesByRoomAsync(
                request.RoomId);

        return schedules.Select(schedule => new ScheduleDto
        {
            Id = schedule.Id,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime
        }).ToList();
    }
}