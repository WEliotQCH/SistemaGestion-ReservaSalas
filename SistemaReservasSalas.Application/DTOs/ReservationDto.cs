using SistemaReservasSalas.Domain.Enums;

namespace SistemaReservasSalas.Application.DTOs;

public class ReservationDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoomId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? Reason { get; set; }

    public ReservationStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}