namespace SistemaReservasSalas.Application.Features.Auth.Responses;

public class AuthenticationResponse
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Token { get; set; } = null!;
}