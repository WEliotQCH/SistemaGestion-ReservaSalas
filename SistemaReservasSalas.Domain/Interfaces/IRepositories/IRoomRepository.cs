using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Application.Abstractions.Persistence;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id);

    Task<List<Room>> GetAllAsync();

    Task AddAsync(Room room);

    Task UpdateAsync(Room room);
}