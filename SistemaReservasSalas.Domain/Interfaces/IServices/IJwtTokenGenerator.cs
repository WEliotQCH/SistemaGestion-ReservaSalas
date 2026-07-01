namespace SistemaReservasSalas.Domain.Interfaces.IServices;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        int userId,
        string email,
        int roleId);
}