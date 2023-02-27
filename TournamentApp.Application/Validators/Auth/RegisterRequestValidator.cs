using FluentValidation;
using TournamentApp.Application.Models.Auth;

namespace TournamentApp.Application.Validators.Auth;
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(rr => rr.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(rr => rr.Password).NotNull().NotEmpty().MinimumLength(6);
        RuleFor(rr => rr.ConfirmPassword).Equal(rr => rr.Password);
    }
}
