using FluentValidation;
using SistemaReservasSalas.Application.Features.Auth.Commands.Login;

namespace SistemaReservasSalas.Application.Validators;

public class LoginCommandValidator
    : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}