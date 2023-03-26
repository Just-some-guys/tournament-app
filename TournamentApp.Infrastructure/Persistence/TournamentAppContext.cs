﻿using Microsoft.EntityFrameworkCore;
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
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Bracket> Brackets { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentAppContext).Assembly);

        modelBuilder.Entity<Tournament>()
        .HasMany(e => e.TournamentTeams)
        .WithOne(t => t.Tournament).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Player>()
            .HasOne(_ => _.Team).WithMany(e => e.Players).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Tournament>()
            .HasOne(b => b.Bracket)
            .WithOne(i => i.Tournament).
            HasForeignKey<Bracket>(b => b.TournamentId);


    }

}
