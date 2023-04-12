using Microsoft.EntityFrameworkCore;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Infrastructure.Persistence;
public class TournamentAppContext : DbContext, ITournamentAppContext
{
    public TournamentAppContext(DbContextOptions<TournamentAppContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Bracket> Brackets { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentAppContext).Assembly);

        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        modelBuilder.Entity<Tournament>()
            .HasOne(b => b.Bracket)
            .WithOne(i => i.Tournament).
            HasForeignKey<Bracket>(b => b.TournamentId);


    }
}
