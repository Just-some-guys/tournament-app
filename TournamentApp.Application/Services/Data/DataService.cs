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
            //Создание Users

            for (int i = 1; i <= 16; i++)
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

            //Создание Teams и Players
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


            //Создание Organizations

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


            foreach (int Id in OrganizationsId)
            {
                Tournament tournament= new Tournament
                {
                    CreatorId = Id,
                    Name = $"Tournament {Id}",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2023, 7, 20),
                    Rules = $"Rules {Id}",
                    Prize = $"Prize {Id}",
                    CommunicationType = new CommunicationType { Name = $"Discord" },
                    CommunicationAddres = $"DiscordChanel",
                    MinTeamNumber = 12,
                    MaxTeamNumber = 16,
                    CheckIn = false,
                    MinutesUntilRegEnd = 60,
                    CanPlayerSetResult = true,
                    Logo = $"Logo {Id}",
                    Description = $"Description {Id}",
                    ScreenResult = true,
                    TournamentType = TournamentType.PremadeTeamAndFreeAgents,
                    TournamentParametres = $"Parametres", // Это поле вообще нужно будет убрать
                    Published = true,
                    TournamentTeams = new List<TournamentTeam>(),
                    GroupStage = new GroupStage
                    {
                        Groups = new List<Group>()
                    },
                    Bracket = new Bracket
                    {

                        Matches = new List<Match>(),

                    },
                    BracketType = BracketType.DoubleElimination
                };
                 _context.Tournaments.Add(tournament);

                await _context.SaveChangesAsync(CancellationToken.None);
            }          
                                       

            
        }

        public async Task RemoveData()
        {
            _context.OrganizationMembers.RemoveRange(_context.OrganizationMembers);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Players.RemoveRange(_context.Players);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Teams.RemoveRange(_context.Teams);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Users.RemoveRange(_context.Users);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Brackets.RemoveRange(_context.Brackets);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Tournaments.RemoveRange(_context.Tournaments);
            await _context.SaveChangesAsync(CancellationToken.None);

            //_context.CommunicationTypes.RemoveRange(_context.CommunicationTypes);
            //await _context.SaveChangesAsync(CancellationToken.None);

            _context.Organizations.RemoveRange(_context.Organizations);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
