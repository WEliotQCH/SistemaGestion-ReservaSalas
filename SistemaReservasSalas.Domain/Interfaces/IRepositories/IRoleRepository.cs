using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Domain.Interfaces.IRepositories;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);

    Task<List<Role>> GetAllAsync();
}