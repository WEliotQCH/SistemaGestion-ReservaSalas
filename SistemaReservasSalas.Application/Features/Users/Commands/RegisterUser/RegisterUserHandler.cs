using BCrypt.Net;
using MediatR;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserHandler
    : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var passwordHash =
            BCrypt.Net.BCrypt.HashPassword(
                request.Password);

        var user = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            passwordHash,
            request.RoleId);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}