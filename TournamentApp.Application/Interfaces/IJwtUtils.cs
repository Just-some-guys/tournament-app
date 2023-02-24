using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces;
public interface IJwtUtils
{
    public string GenerateJwtToken(User user);

    public int? ValidateJwtToken(string token);

    public Task<RefreshToken> GenerateRefreshTokenAsync();
}
