using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Domain.Interfaces.IRepositories;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id);

    Task<List<Room>> GetAllAsync();

    Task AddAsync(Room room);

    Task UpdateAsync(Room room);
}