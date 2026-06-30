using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Application.Abstractions.Persistence;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(int id);

    Task<List<Reservation>> GetAllAsync();

    Task<List<Reservation>> GetByRoomAsync(int roomId);

    Task AddAsync(Reservation reservation);

    Task UpdateAsync(Reservation reservation);

    Task<bool> ExistsConflictAsync(
        int roomId,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime);
}