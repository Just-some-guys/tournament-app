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

            for (int i = 1; i <= 80; i++)
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

            for (int i = 0; i < UserIDs.Count; i += 5)
            {
                List<Player> Players = new List<Player>();

                for (int j = 0; j < 5; j++)
                {
                    Players.Add(new Player
                    {
                        Name = $"Team User{UserIDs[i]} Player {j + 1}",
                        Rank = " ",
                        Role = j == 0 ? PlayerRole.Captain : PlayerRole.Player,
                        UserId = UserIDs[i + j]
                    });
                }

                _context.Teams.Add(new Team
                {
                    Name = $"Team User{UserIDs[i]}",
                    Icon = $"icon {UserIDs[i]}",
                    Region = Region.EUW,
                    Players = Players
                });

                await _context.SaveChangesAsync(CancellationToken.None);

            }

            //Создание Organizations
            _context.Organizations.Add(new Organization
            {
                Name = $"OrganizationName",
                Description = $"Description",
                Logo = $"Logo ",
                OrganizationMembers = new List<OrganizationMember> { new OrganizationMember
                    {
                        UserId = _context.Users.First().Id,
                        OrganizationRole = OrganizationRole.Owner
                    } }
            });

            await _context.SaveChangesAsync(CancellationToken.None);

            // Создание CommunicationTypes
            {
                List<CommunicationType> communicationTypes = new List<CommunicationType>
                {
                    new CommunicationType{Name="Discord"},
                    new CommunicationType{Name="Mail"},
                    new CommunicationType{Name="Vk"}
                };
                _context.CommunicationTypes.AddRange(communicationTypes);
                _context.SaveChangesAsync(CancellationToken.None);
            }

            // Создание турниров
            List<Tournament> tournaments = new List<Tournament>();
            Organization organization = _context.Organizations.FirstOrDefault();

            for (int i = 0; i < 10; i++)
            {
                tournaments.Add(new Tournament
                {
                    CreatorId = organization.Id,
                    Name = $"Tournament {i}",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2023, 7, 20),
                    Rules = $"Rules {i}",
                    Prize = $"Prize {i}",
                    CommunicationTypeId = _context.CommunicationTypes.First().Id,
                    CommunicationAddres = $"DiscordChanel",
                    MinTeamNumber = 12,
                    MaxTeamNumber = 16,
                    CheckIn = false,
                    MinutesUntilRegEnd = 60,
                    CanPlayerSetResult = true,
                    Logo = $"Logo {i}",
                    Description = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in sodales metus, vitae pretium nisl. Proin placerat tempus arcu. Nam eget dolor laoreet, porttitor tortor vel, porttitor nulla. Maecenas nulla velit, fermentum ut nibh eget, luctus ornare sapien. Duis purus turpis, rutrum quis diam a, viverra feugiat risus. Cras lectus urna, imperdiet a sem et, scelerisque congue sapien. Sed fringilla tellus ac odio aliquet scelerisque. Vestibulum eget nisi vitae nibh lobortis tempus. Mauris lacus libero, malesuada eget libero in, vulputate tristique tellus. Morbi varius hendrerit mauris, ac hendrerit elit pharetra vel",
                    ScreenResult = true,
                    PreFinalRoundType = RoundType.BO1,
                    FinalRoundType = RoundType.BO3,
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
                });
            }
            _context.Tournaments.AddRange(tournaments);
            await _context.SaveChangesAsync(CancellationToken.None);


            // Создание TournamentTeams

            List<int> TeamIds = _context.Teams.Select(x => x.Id).ToList();
            int TournamentId = _context.Tournaments.First().Id;
            List<TournamentTeam> tournamentTeams = new List<TournamentTeam>();
            foreach(int teamId in TeamIds)
            {
                tournamentTeams.Add(new TournamentTeam
                {
                    TeamId = teamId,
                    TournamentId = TournamentId
                });
            }
            _context.TournamentTeams.AddRange(tournamentTeams);
            await _context.SaveChangesAsync(CancellationToken.None);

        }

        public async Task RemoveData()
        {
            _context.OrganizationMembers.RemoveRange(_context.OrganizationMembers);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Players.RemoveRange(_context.Players);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.TournamentTeams.RemoveRange(_context.TournamentTeams);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Teams.RemoveRange(_context.Teams);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Users.RemoveRange(_context.Users);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Brackets.RemoveRange(_context.Brackets);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.GroupStages.RemoveRange(_context.GroupStages);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Tournaments.RemoveRange(_context.Tournaments);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.CommunicationTypes.RemoveRange(_context.CommunicationTypes);
            await _context.SaveChangesAsync(CancellationToken.None);

            _context.Organizations.RemoveRange(_context.Organizations);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
