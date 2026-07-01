using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Domain.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);
}