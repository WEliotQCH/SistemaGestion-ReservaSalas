using Microsoft.EntityFrameworkCore;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Infrastructure.Persistence.Repositories;

public class RoomScheduleRepository : IRoomScheduleRepository
{
    private readonly AppDbContext _context;

    public RoomScheduleRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(
        int roomId,
        int scheduleId)
    {
        return await _context.RoomSchedules
            .AnyAsync(x =>
                x.RoomId == roomId &&
                x.ScheduleId == scheduleId);
    }

    public async Task<RoomSchedule?> GetAsync(
        int roomId,
        int scheduleId)
    {
        return await _context.RoomSchedules
            .FirstOrDefaultAsync(x =>
                x.RoomId == roomId &&
                x.ScheduleId == scheduleId);
    }

    public async Task AddAsync(
        RoomSchedule roomSchedule)
    {
        await _context.RoomSchedules
            .AddAsync(roomSchedule);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(
        RoomSchedule roomSchedule)
    {
        _context.RoomSchedules
            .Remove(roomSchedule);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Schedule>> GetSchedulesByRoomAsync(
        int roomId)
    {
        return await _context.RoomSchedules
            .Where(x => x.RoomId == roomId)
            .Join(
                _context.Schedules,
                rs => rs.ScheduleId,
                s => s.Id,
                (rs, s) => s)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
    }

    public async Task<List<Room>> GetRoomsByScheduleAsync(
        int scheduleId)
    {
        return await _context.RoomSchedules
            .Where(x => x.ScheduleId == scheduleId)
            .Join(
                _context.Rooms,
                rs => rs.RoomId,
                r => r.Id,
                (rs, r) => r)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}