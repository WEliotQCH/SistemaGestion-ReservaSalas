using SistemaReservasSalas.Domain.Common;

namespace SistemaReservasSalas.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; } = null!;

    private Role() { }

    public Role(string name)
    {
        Name = name;
    }
}