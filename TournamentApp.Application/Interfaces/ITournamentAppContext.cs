using Microsoft.EntityFrameworkCore;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces;
public interface ITournamentAppContext
{
    public DbSet<GameType> GameTypes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
