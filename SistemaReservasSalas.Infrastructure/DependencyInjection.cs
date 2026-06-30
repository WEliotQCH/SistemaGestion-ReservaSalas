using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;
using SistemaReservasSalas.Domain.Interfaces.IServices;
using SistemaReservasSalas.Infrastructure.Persistence;
using SistemaReservasSalas.Infrastructure.Persistence.Repositories;
using SistemaReservasSalas.Infrastructure.Services;

namespace SistemaReservasSalas.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString(
                "DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
        });
        
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRoomScheduleRepository, RoomScheduleRepository>();
        
        // Services
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
 
        return services;
    }
}