using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaReservasSalas.Domain.Entities;

namespace SistemaReservasSalas.Infrastructure.Persistence.Configurations;

public class RoomScheduleConfiguration : IEntityTypeConfiguration<RoomSchedule>
{
    public void Configure(EntityTypeBuilder<RoomSchedule> builder)
    {
        builder.ToTable("room_schedules");

        builder.HasKey(x => new
        {
            x.RoomId,
            x.ScheduleId
        });

        builder.Property(x => x.RoomId)
            .HasColumnName("room_id");

        builder.Property(x => x.ScheduleId)
            .HasColumnName("schedule_id");

        builder.HasOne<Room>()
            .WithMany()
            .HasForeignKey(x => x.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Schedule>()
            .WithMany()
            .HasForeignKey(x => x.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}