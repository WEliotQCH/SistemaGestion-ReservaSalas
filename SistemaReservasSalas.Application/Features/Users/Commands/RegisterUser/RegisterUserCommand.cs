using MediatR;

namespace SistemaReservasSalas.Application.Features.Users.Commands.RegisterUser;

public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int RoleId
) : IRequest<int>;