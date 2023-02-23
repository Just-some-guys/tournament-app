using Microsoft.EntityFrameworkCore;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Infrastructure.Persistence;
public class TournamentAppContext : DbContext
{
    public TournamentAppContext(DbContextOptions<TournamentAppContext> options) : base(options)
    {
    }

    public DbSet<GameType> GameTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentAppContext).Assembly);
    }

}
