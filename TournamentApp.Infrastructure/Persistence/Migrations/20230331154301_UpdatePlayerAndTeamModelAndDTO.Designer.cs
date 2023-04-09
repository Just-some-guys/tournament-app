﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentApp.Infrastructure.Persistence;

#nullable disable

namespace TournamentApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(TournamentAppContext))]
    [Migration("20230331154301_UpdatePlayerAndTeamModelAndDTO")]
    partial class UpdatePlayerAndTeamModelAndDTO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Bracket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BracketType")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("Brackets");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GameFromRiotAPI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("TeamNumberOneId")
                        .HasColumnType("int");

                    b.Property<int>("TeamNumberTwoId")
                        .HasColumnType("int");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamNumberOneId");

                    b.HasIndex("TeamNumberTwoId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BracketId")
                        .HasColumnType("int");

                    b.Property<int>("MatchNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NextLooserMatchNumber")
                        .HasColumnType("int");

                    b.Property<int?>("NextMatchNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.HasIndex("RoundId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoundType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.CommunicationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CommunicationType");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.OrganizationMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationRole")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganizationMembers");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaptainId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaptainId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BracketId")
                        .HasColumnType("int");

                    b.Property<bool>("CanPlayerSetResult")
                        .HasColumnType("bit");

                    b.Property<bool>("CheckIn")
                        .HasColumnType("bit");

                    b.Property<string>("CommunicationAddres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommunicationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxTeamNumber")
                        .HasColumnType("int");

                    b.Property<int>("MinTeamNumber")
                        .HasColumnType("int");

                    b.Property<int>("MinutesUntilRegEnd")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ScreenResult")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TournamentParametres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommunicationTypeId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.TournamentTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentTeam");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Bracket", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.Tournament", "Tournament")
                        .WithOne("Bracket")
                        .HasForeignKey("TournamentApp.Domain.Entities.BracketEntities.Bracket", "TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Game", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.BracketEntities.Match", "Match")
                        .WithMany("Games")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Team", "TeamNumberOne")
                        .WithMany()
                        .HasForeignKey("TeamNumberOneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Team", "TeamNumberTwo")
                        .WithMany()
                        .HasForeignKey("TeamNumberTwoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("TeamNumberOne");

                    b.Navigation("TeamNumberTwo");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Match", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.BracketEntities.Bracket", null)
                        .WithMany("Matches")
                        .HasForeignKey("BracketId");

                    b.HasOne("TournamentApp.Domain.Entities.BracketEntities.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Round");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Participant", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.BracketEntities.Match", null)
                        .WithMany("Participants")
                        .HasForeignKey("MatchId");

                    b.HasOne("TournamentApp.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.OrganizationMember", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.Organization", "Organization")
                        .WithMany("OrganizationMembers")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Player", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Team", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.User", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Captain");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Tournament", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.CommunicationType", "CommunicationType")
                        .WithMany()
                        .HasForeignKey("CommunicationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Organization", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CommunicationType");

                    b.Navigation("Creator");

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.TournamentTeam", b =>
                {
                    b.HasOne("TournamentApp.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentApp.Domain.Entities.Tournament", "Tournament")
                        .WithMany("TournamentTeams")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Bracket", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.BracketEntities.Match", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Organization", b =>
                {
                    b.Navigation("OrganizationMembers");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.Tournament", b =>
                {
                    b.Navigation("Bracket")
                        .IsRequired();

                    b.Navigation("TournamentTeams");
                });

            modelBuilder.Entity("TournamentApp.Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
