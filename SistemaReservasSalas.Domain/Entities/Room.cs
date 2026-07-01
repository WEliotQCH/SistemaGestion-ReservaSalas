using SistemaReservasSalas.Domain.Common;

namespace SistemaReservasSalas.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string Location { get; private set; } = null!;

    public int Capacity { get; private set; }

    public string? Description { get; private set; }

    public bool Active { get; private set; }

    private Room() { }

    public Room(
        string name,
        string location,
        int capacity,
        string? description)
    {
        Name = name;
        Location = location;
        Capacity = capacity;
        Description = description;
        Active = true;
    }
    public void Update(
        string name,
        string location,
        int capacity,
        string? description)
    {
        Name = name;
        Location = location;
        Capacity = capacity;
        Description = description;
    }
    public void Deactivate()
    {
        Active = false;
    }

    public void Activate()
    {
        Active = true;
    }
}