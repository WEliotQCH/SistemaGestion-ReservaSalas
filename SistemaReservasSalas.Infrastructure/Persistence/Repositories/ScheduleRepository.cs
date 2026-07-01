using Microsoft.EntityFrameworkCore;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Infrastructure.Persistence.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly AppDbContext _context;

    public ScheduleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Schedule?> GetByIdAsync(int id)
    {
        return await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Schedule>> GetAllAsync()
    {
        return await _context.Schedules
            .OrderBy(x => x.StartTime)
            .ThenBy(x => x.EndTime)
            .ToListAsync();
    }

    public async Task AddAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Schedule schedule)
    {
        _context.Schedules.Update(schedule);

        await _context.SaveChangesAsync();
    }
}