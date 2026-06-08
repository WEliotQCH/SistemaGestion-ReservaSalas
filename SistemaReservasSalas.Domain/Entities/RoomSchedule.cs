namespace SistemaReservasSalas.Domain.Entities;

public class RoomSchedule
{
    public int RoomId { get; private set; }

    public int ScheduleId { get; private set; }

    private RoomSchedule() { }

    public RoomSchedule(
        int roomId,
        int scheduleId)
    {
        RoomId = roomId;
        ScheduleId = scheduleId;
    }
}