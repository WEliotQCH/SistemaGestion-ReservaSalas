using Microsoft.EntityFrameworkCore;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Enums;


namespace SistemaReservasSalas.Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Reservation>> GetByRoomAsync(int roomId)
    {
        return await _context.Reservations
            .Where(x => x.RoomId == roomId)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.StartTime)
            .ToListAsync();
    }

    public async Task AddAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsConflictAsync(
        int roomId,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime)
    {
        return await _context.Reservations
            .AnyAsync(x =>
                x.RoomId == roomId &&
                x.Date == date &&
                x.Status == ReservationStatus.Active &&
                startTime < x.EndTime &&
                endTime > x.StartTime);
    }
}