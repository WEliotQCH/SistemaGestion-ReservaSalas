using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Application.Abstractions.Persistence;

public interface IScheduleRepository
{
    Task<Schedule?> GetByIdAsync(int id);

    Task<List<Schedule>> GetAllAsync();
    
    Task AddAsync(Schedule schedule);

    Task UpdateAsync(Schedule schedule);
}