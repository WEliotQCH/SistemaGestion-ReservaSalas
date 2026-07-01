using MediatR;
using SistemaReservasSalas.Application.DTOs;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Rooms.Queries.GetRoomById;

public class GetRoomByIdHandler
    : IRequestHandler<GetRoomByIdQuery, RoomDto?>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomByIdHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<RoomDto?> Handle(
        GetRoomByIdQuery request,
        CancellationToken cancellationToken)
    {
        var room =
            await _roomRepository.GetByIdAsync(request.Id);

        if (room is null)
            return null;

        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Location = room.Location,
            Capacity = room.Capacity,
            Description = room.Description,
            Active = room.Active
        };
    }
}