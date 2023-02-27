using FluentValidation;

namespace TournamentApp.Application.Models.Auth;
public class AuthenticateRequest
{
    public string Email { get; set; }

    public string Password { get; set; }
}
