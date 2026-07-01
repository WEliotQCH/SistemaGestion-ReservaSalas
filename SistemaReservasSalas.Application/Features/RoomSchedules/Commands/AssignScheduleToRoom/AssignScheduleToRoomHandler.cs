using MediatR;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Commands.AssignScheduleToRoom;

public class AssignScheduleToRoomHandler
    : IRequestHandler<AssignScheduleToRoomCommand, bool>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IRoomScheduleRepository _roomScheduleRepository;

    public AssignScheduleToRoomHandler(
        IRoomRepository roomRepository,
        IScheduleRepository scheduleRepository,
        IRoomScheduleRepository roomScheduleRepository)
    {
        _roomRepository = roomRepository;
        _scheduleRepository = scheduleRepository;
        _roomScheduleRepository = roomScheduleRepository;
    }

    public async Task<bool> Handle(
        AssignScheduleToRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room =
            await _roomRepository.GetByIdAsync(request.RoomId);

        if (room is null)
            return false;

        var schedule =
            await _scheduleRepository.GetByIdAsync(request.ScheduleId);

        if (schedule is null)
            return false;

        var exists =
            await _roomScheduleRepository.ExistsAsync(
                request.RoomId,
                request.ScheduleId);

        if (exists)
            return false;

        var roomSchedule = new RoomSchedule(
            request.RoomId,
            request.ScheduleId);

        await _roomScheduleRepository.AddAsync(
            roomSchedule);

        return true;
    }
}