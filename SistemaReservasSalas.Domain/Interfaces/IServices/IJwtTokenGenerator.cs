namespace SistemaReservasSalas.Application.Abstractions.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        int userId,
        string email,
        int roleId);
}