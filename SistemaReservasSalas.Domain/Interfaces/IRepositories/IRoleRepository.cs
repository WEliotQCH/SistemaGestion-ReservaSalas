using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Application.Abstractions.Persistence;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);

    Task<List<Role>> GetAllAsync();
}