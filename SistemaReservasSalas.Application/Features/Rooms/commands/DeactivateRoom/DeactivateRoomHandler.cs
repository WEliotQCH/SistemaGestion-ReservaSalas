using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.DeactivateRoom;

public class DeactivateRoomHandler
    : IRequestHandler<DeactivateRoomCommand, bool>
{
    private readonly IRoomRepository _roomRepository;

    public DeactivateRoomHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<bool> Handle(
        DeactivateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room =
            await _roomRepository.GetByIdAsync(request.Id);

        if (room is null)
            return false;

        room.Deactivate();

        await _roomRepository.UpdateAsync(room);

        return true;
    }
}