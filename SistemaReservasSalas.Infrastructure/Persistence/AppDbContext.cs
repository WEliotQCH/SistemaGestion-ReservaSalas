using Microsoft.EntityFrameworkCore;
using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Schedule> Schedules => Set<Schedule>();

    public DbSet<RoomSchedule> RoomSchedules => Set<RoomSchedule>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}