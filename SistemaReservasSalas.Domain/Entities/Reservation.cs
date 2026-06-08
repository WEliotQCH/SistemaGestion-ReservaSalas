using SistemaReservasSalas.Domain.Common;
using SistemaReservasSalas.Domain.Enums;

namespace SistemaReservasSalas.Domain.Entities;

public class Reservation : BaseEntity
{
    public int UserId { get; private set; }

    public int RoomId { get; private set; }

    public DateOnly Date { get; private set; }

    public TimeOnly StartTime { get; private set; }

    public TimeOnly EndTime { get; private set; }

    public string? Reason { get; private set; }

    public ReservationStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Reservation() { }

    public Reservation(
        int userId,
        int roomId,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        string? reason)
    {
        UserId = userId;
        RoomId = roomId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Reason = reason;
        Status = ReservationStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Status = ReservationStatus.Cancelled;
    }

    public void Update(
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        string? reason)
    {
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Reason = reason;
    }
}