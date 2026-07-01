using MediatR;
using SistemaReservasSalas.Application.Features.Auth.Responses;

namespace SistemaReservasSalas.Application.Features.Auth.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<AuthenticationResponse?>;