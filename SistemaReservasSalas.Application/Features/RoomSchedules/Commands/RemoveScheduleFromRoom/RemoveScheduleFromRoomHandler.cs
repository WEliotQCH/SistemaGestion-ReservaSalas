using MediatR;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Commands.RemoveScheduleFromRoom;

public class RemoveScheduleFromRoomHandler
    : IRequestHandler<RemoveScheduleFromRoomCommand, bool>
{
    private readonly IRoomScheduleRepository _roomScheduleRepository;

    public RemoveScheduleFromRoomHandler(
        IRoomScheduleRepository roomScheduleRepository)
    {
        _roomScheduleRepository = roomScheduleRepository;
    }

    public async Task<bool> Handle(
        RemoveScheduleFromRoomCommand request,
        CancellationToken cancellationToken)
    {
        var roomSchedule =
            await _roomScheduleRepository.GetAsync(
                request.RoomId,
                request.ScheduleId);

        if (roomSchedule is null)
            return false;

        await _roomScheduleRepository.RemoveAsync(
            roomSchedule);

        return true;
    }
}