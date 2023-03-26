using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces;
public interface IUserService
{
    public Task<User> GetByRefreshTokenAsync(string refreshToken);
    public User GetCurrentUser();
}
