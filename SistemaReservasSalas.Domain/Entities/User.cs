using SistemaReservasSalas.Domain.Common;

namespace SistemaReservasSalas.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public bool Active { get; private set; }

    public int RoleId { get; private set; }

    private User() { }

    public User(
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        int roleId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        RoleId = roleId;
        Active = true;
    }
}