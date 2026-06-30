using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Application.Abstractions.Persistence;

public interface IRoomScheduleRepository
{
    Task<bool> ExistsAsync(
        int roomId,
        int scheduleId);

    Task<RoomSchedule?> GetAsync(
        int roomId,
        int scheduleId);

    Task AddAsync(
        RoomSchedule roomSchedule);

    Task RemoveAsync(
        RoomSchedule roomSchedule);

    Task<List<Schedule>> GetSchedulesByRoomAsync(
        int roomId);

    Task<List<Room>> GetRoomsByScheduleAsync(
        int scheduleId);
}