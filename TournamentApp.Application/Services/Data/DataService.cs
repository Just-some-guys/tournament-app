using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Auth;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Services.Data
{
    public class DataService : IDataService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public DataService(ITournamentAppContext context, IMapper mapper, IAuthService auth)
        {
            _context = context;
            _mapper = mapper;
            _authService = auth;
        }

        public async Task FillData()
        {
            // Создание Users

            for (int i = 1; i <= 4; i++)
            {
                RegisterRequest model = new RegisterRequest
                {
                    Name = $"UserName{i}",
                    Password = $"PasswordUser{i}",
                    ConfirmPassword = $"PasswordUser{i}",
                    Email = $"UserEmail{i}@gmail.com"
                };

                await _authService.RegisterAsync(model, "Request.Headers");

            }
            await _context.SaveChangesAsync(CancellationToken.None);

            // Создание Teams и Players
            List<int> UserIDs = _context.Users.Select(x => x.Id).ToList();

            foreach (int Id in UserIDs)
            {
                _context.Teams.Add(new Team
                {
                    Name = $"Team User{Id}",
                    Icon = "icon",
                    Region = Region.EUW,
                    Players = new List<Player> {new Player
                    {
                        Name = $"SummonerName{Id}",
                        Rank = " ",
                        Role = PlayerRole.Captain,
                        UserId=Id
                    } }
                });

            }
            await _context.SaveChangesAsync(CancellationToken.None);
            
            
            // Создание Organizations

            foreach (int Id in UserIDs)
            {
                _context.Organizations.Add(new Organization
                {
                    Name = $"OrganizationName{Id}",
                    Description = $"Description {Id}",
                    Logo = $"Logo {Id}",
                    OrganizationMembers = new List<OrganizationMember> { new OrganizationMember
                    {
                        UserId = Id,
                        OrganizationRole = OrganizationRole.Owner
                    } }
                });
                await _context.SaveChangesAsync(CancellationToken.None);
            }
            await _context.SaveChangesAsync(CancellationToken.None);


            // Создание турниров

            List<int> OrganizationsId = _context.Organizations.Select(x => x.Id).ToList();

            foreach(int Id in OrganizationsId)
            {
                _context.Tournaments.Add(new Tournament
                {
                    Name = $"Tournament {Id}",
                    CommunicationAddres = $"DiscordChanel",
                    CommunicationType = new CommunicationType { Name = $"Discord" },
                    CheckIn = false,
                    CreatorId = Id,
                    Description = $"Description {Id}",
                    EndDate = new DateTime(2023, 7, 20),
                    StartDate = DateTime.Now,
                    Logo = $"Logo {Id}",
                    MaxTeamNumber = 16,
                    MinTeamNumber = 12,
                    Prize = $"Prize {Id}",
                    CanPlayerSetResult = true,
                    MinutesUntilRegEnd = 60,
                    ScreenResult = true,
                    Rules = $"Rules {Id}",
                    TournamentParametres = $"Parametres", // Это поле вообще нужно будет убрать
                    Published = true,
                    TournamentTeams = new List<TournamentTeam>(),
                    TournamentType = TournamentType.PremadeTeamAndFreeAgents,
                    Bracket = new Bracket
                    {
                        BracketType = BracketType.DoubleElimination,
                        Matches = new List<Match>(),

                    }
                });
            }

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
