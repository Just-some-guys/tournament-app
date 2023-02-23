using Microsoft.EntityFrameworkCore;

namespace TournamentApp.Infrastructure.Persistence;
public class TournamentAppContext : DbContext
{
    public TournamentAppContext(DbContextOptions<TournamentAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentAppContext).Assembly);
    }
}
