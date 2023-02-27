using FluentValidation;
using TournamentApp.Application.Models.Auth;

namespace TournamentApp.Application.Validators.Auth;
public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
{
    public AuthenticateRequestValidator()
    {
        RuleFor(rr => rr.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(rr => rr.Password).NotNull().NotEmpty().MinimumLength(6);
    }
}
