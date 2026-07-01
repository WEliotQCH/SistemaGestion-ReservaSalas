using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.UpdateRoom;

public class UpdateRoomHandler
    : IRequestHandler<UpdateRoomCommand, bool>
{
    private readonly IRoomRepository _roomRepository;

    public UpdateRoomHandler(
        IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<bool> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id);

        if (room is null)
            return false;

        room.Update(
            request.Name,
            request.Location,
            request.Capacity,
            request.Description);

        await _roomRepository.UpdateAsync(room);

        return true;
    }
}