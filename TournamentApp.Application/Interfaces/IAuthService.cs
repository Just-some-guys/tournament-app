using TournamentApp.Application.Auth.Models;

namespace TournamentApp.Application.Interfaces;
public interface IAuthService
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);

    Task<AuthenticateResponse> RefreshTokenAsync(string token);

    Task RegisterAsync(RegisterRequest model, string origin);

    Task VerifyEmailAsync(string token);
}
