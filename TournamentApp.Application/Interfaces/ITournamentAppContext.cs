using Microsoft.EntityFrameworkCore;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces;
public interface ITournamentAppContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Discipline> Disciplines { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);


}
