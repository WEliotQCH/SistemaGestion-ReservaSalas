using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetRoomsBySchedule;

public class GetRoomsByScheduleHandler
    : IRequestHandler<GetRoomsByScheduleQuery, List<RoomDto>>
{
    private readonly IRoomScheduleRepository _roomScheduleRepository;

    public GetRoomsByScheduleHandler(
        IRoomScheduleRepository roomScheduleRepository)
    {
        _roomScheduleRepository = roomScheduleRepository;
    }

    public async Task<List<RoomDto>> Handle(
        GetRoomsByScheduleQuery request,
        CancellationToken cancellationToken)
    {
        var rooms =
            await _roomScheduleRepository.GetRoomsByScheduleAsync(
                request.ScheduleId);

        return rooms.Select(room => new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Location = room.Location,
            Capacity = room.Capacity,
            Description = room.Description,
            Active = room.Active
        }).ToList();
    }
}