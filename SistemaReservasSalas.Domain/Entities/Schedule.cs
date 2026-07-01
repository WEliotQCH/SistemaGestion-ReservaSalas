using SistemaReservasSalas.Domain.Common;

namespace SistemaReservasSalas.Domain.Entities;

public class Schedule : BaseEntity
{
    public TimeOnly StartTime { get; private set; }

    public TimeOnly EndTime { get; private set; }

    private Schedule() { }

    public Schedule(
        TimeOnly startTime,
        TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
    public void Update(
        TimeOnly startTime,
        TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}