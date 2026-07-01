using BCrypt.Net;
using MediatR;
using SistemaReservasSalas.Application.Features.Auth.Responses;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;
using SistemaReservasSalas.Domain.Interfaces.IServices;

namespace SistemaReservasSalas.Application.Features.Auth.Commands.Login;

public class LoginHandler
    : IRequestHandler<LoginCommand, AuthenticationResponse?>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResponse?> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _userRepository.GetByEmailAsync(request.Email);

        if (user is null)
            return null;

        var isValidPassword =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!isValidPassword)
            return null;

        var token =
            _jwtTokenGenerator.GenerateToken(
                user.Id,
                user.Email,
                user.RoleId);

        return new AuthenticationResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Token = token
        };
    }
}