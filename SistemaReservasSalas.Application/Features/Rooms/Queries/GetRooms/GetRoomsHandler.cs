using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Rooms.Queries.GetRooms;

public class GetRoomsHandler
    : IRequestHandler<GetRoomsQuery, List<RoomDto>>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomsHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<List<RoomDto>> Handle(
        GetRoomsQuery request,
        CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllAsync();

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