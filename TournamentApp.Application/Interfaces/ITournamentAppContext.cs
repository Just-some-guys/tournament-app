using Microsoft.EntityFrameworkCore;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Interfaces;
public interface ITournamentAppContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Discipline> Disciplines { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Bracket> Brackets { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Branch> Branches { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);


}
