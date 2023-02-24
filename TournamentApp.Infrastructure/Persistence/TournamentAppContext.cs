using Microsoft.EntityFrameworkCore;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Infrastructure.Persistence;
public class TournamentAppContext : DbContext, ITournamentAppContext
{
    public TournamentAppContext(DbContextOptions<TournamentAppContext> options) : base(options)
    {
    }

    public DbSet<GameType> GameTypes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentAppContext).Assembly);
    }

}
