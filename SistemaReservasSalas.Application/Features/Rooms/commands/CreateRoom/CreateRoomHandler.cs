using MediatR;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomHandler
    : IRequestHandler<CreateRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;

    public CreateRoomHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<int> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room = new Room(
            request.Name,
            request.Location,
            request.Capacity,
            request.Description);

        await _roomRepository.AddAsync(room);

        return room.Id;
    }
}