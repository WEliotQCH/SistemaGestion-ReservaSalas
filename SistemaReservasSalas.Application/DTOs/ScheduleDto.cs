namespace SistemaReservasSalas.Application.DTOs;

public class ScheduleDto
{
    public int Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}