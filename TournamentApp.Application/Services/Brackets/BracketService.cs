using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Brackets;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Services.Brackets
{
    public class BracketService : IBracketService
    {
        private readonly ITournamentAppContext _context;

        private readonly IMapper _mapper;

        public BracketService(
            ITournamentAppContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DoubleEliminationBracketDto GetDEModelDtoAuto()
        {
            Tournament tournament = new Tournament(); // Должен передаваться в параметры

            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.
            List<TournamentTeam> teams = tournament.TournamentTeams;
            DoubleEliminationBracket result = new DoubleEliminationBracket();

            result.UpperBranch = new List<Match>();
            result.LowerBranch = new List<Match>();

            // Создаются матчи верхней сетки
            for (int i = 1; i <= numberOfTeams; i++)
            {
                result.UpperBranch.Add(new Match { Name = $"Match{i}", MatchNumber = i });
            }

            // Создаются матчи нижней сетки
            for (int matchId = numberOfTeams + 1; matchId <= numberOfTeams * 2 - 2; matchId++)
            {
                result.LowerBranch.Add(new Match { Name = $"Match{matchId}", MatchNumber = matchId });
            }

            // Этот цикл добавляет команды в матчи
            for (int i = 0; i < numberOfTeams / 2; i++)
            {
                for (int g = 0; g < numberOfTeams; g += 2)
                {
                    result.UpperBranch[i].Participants = new List<TournamentTeam>();
                }
            }

            foreach (Match match in result.LowerBranch)
            {
                match.Participants = new List<TournamentTeam>();
            }

            // Этот цикл проставляет NextMatchNumber для верхней сетки
            {
                int upStep = numberOfTeams / 2;
                for (int i = 0; i < result.UpperBranch.Count; i += 2)
                {
                    result.UpperBranch[i].NextMatchNumber = i + 1 + upStep;
                    result.UpperBranch[i + 1].NextMatchNumber = i + 1 + upStep;
                    upStep -= 1;
                }
            }

            // Проставляются NextMatchNumber для нижней сетки
            {
                result.LowerBranch[result.LowerBranch.Count - 1].NextMatchNumber = numberOfTeams;
                result.LowerBranch[result.LowerBranch.Count - 2].NextMatchNumber = numberOfTeams * 2 - 2;
                int lowStep = 2;
                int p = 0;
                int o = 0;
                int counter = 1;
                int c = 0;
                for (int i = result.LowerBranch.Count - 3; i >= 0; i -= o)
                {
                    p = 0;
                    o = 0;
                    c = 0;
                    counter = 1;

                    if (counter == 1)
                    {
                        for (int j = 0; j < lowStep; j++)
                        {
                            if (j != 0 && j % 2 == 0) { c++; }
                            result.LowerBranch[i - j].NextMatchNumber = result.LowerBranch[i + lowStep / 2 - c].MatchNumber;
                            p = j + 1;
                            o++;
                        }
                        counter++;
                    }
                    if (counter == 2)
                    {
                        for (int k = 0; k < lowStep; k++)
                        {
                            result.LowerBranch[i - p - k].NextMatchNumber = result.LowerBranch[i - p - k + lowStep].MatchNumber;
                            o++;
                        }
                        lowStep *= 2;
                    }
                }
            }

            // Проставляются LoserMatchNumber для верхней сетки
            {
                for (int i = 0; i < numberOfTeams / 4; i++)
                {
                    result.UpperBranch[i * 2].NextLooserMatchNumber = result.LowerBranch[i].MatchNumber;
                    result.UpperBranch[i * 2 + 1].NextLooserMatchNumber = result.LowerBranch[i].MatchNumber;
                }

                int counter;
                int step = numberOfTeams / 4;
                int numberLW = numberOfTeams / 4;
                int o;
                for (int i = numberOfTeams / 2; i < numberOfTeams - 1; i += o)
                {
                    counter = 1;
                    o = 0;
                    for (int j = 0; j < step; j++)
                    {
                        if (counter == 1)
                        {
                            result.UpperBranch[i + j].NextLooserMatchNumber = result.LowerBranch[numberLW].MatchNumber;
                            numberLW++;
                            o++;
                            if (j == step - 1)
                            {
                                counter++;
                                step /= 2;
                            }
                        }

                        if (counter == 2)
                        {
                            numberLW += step;
                        }
                    }
                }
            }

            result.UpperBranch[^1].NextMatchNumber = null;
            result.UpperBranch[^1].NextLooserMatchNumber = null;
            var bracket = new DoubleEliminationBracketDto
            {
                Lower = _mapper.Map<List<MatchDto>>(result.LowerBranch),
                Upper = _mapper.Map<List<MatchDto>>(result.UpperBranch)
            };

            return bracket;
        }

        public DoubleEliminationBracket CreateDoubleEliminationBracket()
        {
            Tournament tournament = new Tournament { Id = 1 };
            List<Team> teamsFromTournament = new List<Team>();
            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.

            // в будуем этот цикл будет не нужен, команды будут передаваться из турнира
            for (int i = 0; i < numberOfTeams; i++)
            {
                teamsFromTournament.Add(new Team
                {
                    Name = $" TeamName {i}",
                    Icon = $"Team icon {i}",
                    Players = new List<Player>(),
                    Region = Region.EUW,
                    Id = i + 1,
                });
            }

            List<TournamentTeam> teams = new List<TournamentTeam>();
            foreach (Team team in teamsFromTournament)
            {
                teams.Add(new TournamentTeam
                {
                    TeamId = team.Id,
                    TournamentId = tournament.Id,
                    Id = team.Id
                });
            }


            DoubleEliminationBracket result = new DoubleEliminationBracket();

            result.UpperBranch = new List<Match>();
            result.LowerBranch = new List<Match>();

            // Создаются матчи верхней сетки
            for (int i = 1; i <= numberOfTeams; i++)
            {
                result.UpperBranch.Add(new Match { Name = $"Match{i}", MatchNumber = i });
            }

            // Создаются матчи нижней сетки
            for (int matchId = numberOfTeams + 1; matchId <= numberOfTeams * 2 - 2; matchId++)
            {
                result.LowerBranch.Add(new Match { Name = $"Match{matchId}", MatchNumber = matchId });
            }

            // Этот цикл добавляет команды в матчи
            int teamNumber = 0;
            for (int i = 0; i < numberOfTeams / 2; i++)
            {
                List<TournamentTeam> tournamentTeams = new List<TournamentTeam>();
                tournamentTeams.Add(new TournamentTeam { Id = teams[teamNumber].Id });
                tournamentTeams.Add(new TournamentTeam { Id = teams[teamNumber + 1].Id });
                result.UpperBranch[i].Participants = tournamentTeams;
                teamNumber += 2;

            }

            foreach (Match match in result.LowerBranch)
            {
                match.Participants = new List<TournamentTeam>();
            }

            // Этот цикл проставляет NextMatchNumber для верхней сетки
            {
                int upStep = numberOfTeams / 2;
                for (int i = 0; i < result.UpperBranch.Count; i += 2)
                {

                    result.UpperBranch[i].NextMatchNumber = i + 1 + upStep;
                    result.UpperBranch[i + 1].NextMatchNumber = i + 1 + upStep;
                    upStep -= 1;
                }
            }
            // Проставляются раунды для верхней сетки
            {
                int roundStep = numberOfTeams / 2;
                int roundNumber = 1;
                for (int i = 0; i < result.UpperBranch.Count; i += roundStep * 2)
                {
                    for (int j = 0; j < roundStep; j++)
                    {
                        result.UpperBranch[i + j].Round = new Round
                        {
                            RoundNumber = roundNumber,
                            RoundType = RoundType.BO1
                        };
                    }
                    roundStep = roundStep / 2;
                    if (roundStep == 0)
                    {
                        result.UpperBranch[i + 1].Round = new Round
                        {
                            RoundNumber = roundNumber + 1,
                            RoundType = RoundType.BO1
                        };
                        break;
                    }
                    roundNumber++;
                }
            }

            // Проставляются NextMatchNumber для нижней сетки
            {
                result.LowerBranch[result.LowerBranch.Count - 1].NextMatchNumber = numberOfTeams;
                result.LowerBranch[result.LowerBranch.Count - 2].NextMatchNumber = numberOfTeams * 2 - 2;
                int lowStep = 2;
                int p = 0;
                int o = 0;
                int counter = 1;
                int c = 0;
                for (int i = result.LowerBranch.Count - 3; i >= 0; i -= o)
                {
                    p = 0;
                    o = 0;
                    c = 0;
                    counter = 1;

                    if (counter == 1)
                    {
                        for (int j = 0; j < lowStep; j++)
                        {
                            if (j != 0 && j % 2 == 0) { c++; }
                            result.LowerBranch[i - j].NextMatchNumber = result.LowerBranch[i + lowStep / 2 - c].MatchNumber;
                            p = j + 1;
                            o++;
                        }
                        counter++;
                    }
                    if (counter == 2)
                    {
                        for (int k = 0; k < lowStep; k++)
                        {
                            result.LowerBranch[i - p - k].NextMatchNumber = result.LowerBranch[i - p - k + lowStep].MatchNumber;
                            o++;
                        }
                        lowStep *= 2;
                    }
                }
            }

            // Проставляются LoserMatchNumber для верхней сетки
            {
                for (int i = 0; i < numberOfTeams / 4; i++)
                {
                    result.UpperBranch[i * 2].NextLooserMatchNumber = result.LowerBranch[i].MatchNumber;
                    result.UpperBranch[i * 2 + 1].NextLooserMatchNumber = result.LowerBranch[i].MatchNumber;
                }

                int counter;
                int step = numberOfTeams / 4;
                int numberLW = numberOfTeams / 4;
                int o;
                for (int i = numberOfTeams / 2; i < numberOfTeams - 1; i += o)
                {
                    counter = 1;
                    o = 0;
                    for (int j = 0; j < step; j++)
                    {
                        if (counter == 1)
                        {
                            result.UpperBranch[i + j].NextLooserMatchNumber = result.LowerBranch[numberLW].MatchNumber;
                            numberLW++;
                            o++;
                            if (j == step - 1)
                            {
                                counter++;
                                step /= 2;
                            }
                        }

                        if (counter == 2)
                        {
                            numberLW += step;
                        }
                    }
                }
            }

            result.UpperBranch[^1].NextMatchNumber = null;
            result.UpperBranch[^1].NextLooserMatchNumber = null;

            return result;
        }

        public SingleEliminationBracket CreateSingleEliminationBracket()
        {
            Tournament tournament = new Tournament { Id = 1 };
            List<Team> teamsFromTournament = new List<Team>();
            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.

            // в будуем этот цикл будет не нужен, команды будут передаваться из турнира
            for (int i = 0; i < numberOfTeams; i++)
            {
                teamsFromTournament.Add(new Team
                {
                    Name = $" TeamName {i}",
                    Icon = $"Team icon {i}",
                    Players = new List<Player>(),
                    Region = Region.EUW,
                    Id = i + 1,
                });
            }

            List<TournamentTeam> teams = new List<TournamentTeam>();
            foreach (Team team in teamsFromTournament)
            {
                teams.Add(new TournamentTeam
                {
                    TeamId = team.Id,
                    TournamentId = tournament.Id,
                    Id = team.Id
                });
            }


            SingleEliminationBracket result = new SingleEliminationBracket();
            result.UpperBranch = new List<Match>();


            // Создаются матчи верхней сетки
            for (int i = 1; i <= numberOfTeams; i++)
            {
                result.UpperBranch.Add(new Match { Name = $"Match{i}", MatchNumber = i });
            }
            // Этот цикл добавляет команды в матчи
            int teamNumber = 0;
            for (int i = 0; i < numberOfTeams / 2; i++)
            {
                List<TournamentTeam> tournamentTeams = new List<TournamentTeam>();
                tournamentTeams.Add(new TournamentTeam { Id = teams[teamNumber].Id });
                tournamentTeams.Add(new TournamentTeam { Id = teams[teamNumber + 1].Id });
                result.UpperBranch[i].Participants = tournamentTeams;
                teamNumber += 2;

            }

            // Этот цикл проставляет NextMatchNumber для верхней сетки
            {
                int upStep = numberOfTeams / 2;
                for (int i = 0; i < result.UpperBranch.Count; i += 2)
                {

                    result.UpperBranch[i].NextMatchNumber = i + 1 + upStep;
                    result.UpperBranch[i + 1].NextMatchNumber = i + 1 + upStep;
                    upStep -= 1;
                }
            }
            // Проставляются раунды для верхней сетки
            {
                int roundStep = numberOfTeams / 2;
                int roundNumber = 1;
                for (int i = 0; i < result.UpperBranch.Count; i += roundStep * 2)
                {
                    for (int j = 0; j < roundStep; j++)
                    {
                        result.UpperBranch[i + j].Round = new Round
                        {
                            RoundNumber = roundNumber,
                            RoundType = RoundType.BO1
                        };
                    }
                    roundStep = roundStep / 2;
                    if (roundStep == 0)
                    {
                        result.UpperBranch[i + 1].Round = new Round
                        {
                            RoundNumber = roundNumber + 1,
                            RoundType = RoundType.BO1
                        };
                        break;
                    }
                    roundNumber++;
                }
            }

            result.UpperBranch[^1].NextMatchNumber = null;
            result.UpperBranch[^1].NextLooserMatchNumber = null;

            return result;
        }


        public async Task CreateDEModel(int tournamentId)
        {
            Tournament tournament = _context.Tournaments
                .Include(_ => _.TournamentTeams)
                .Include(_ => _.Bracket).ThenInclude(_ => _.Matches)
                .FirstOrDefault(_ => _.Id == tournamentId);

            int numberOfTeams = 16;

            List<TournamentTeam> tournamentTeams = tournament.TournamentTeams;
            // Здесь надо дополнить количество команд до нужного значения 
            // пустыми командами и перемешать так, чтобы не было двух пустых команд подряд

            List<Match> UpperBranch = new List<Match>();
            List<Match> LowerBranch = new List<Match>();

            // Создаются матчи верхней сетки
            for (int i = 1; i <= numberOfTeams; i++)
            {
                UpperBranch.Add(new Match { Name = $"Match{i}", MatchNumber = i, Participants = new List<TournamentTeam>() });
            }

            // Создаются матчи нижней сетки
            for (int matchId = numberOfTeams + 1; matchId <= numberOfTeams * 2 - 2; matchId++)
            {
                LowerBranch.Add(new Match { Name = $"Match{matchId}", MatchNumber = matchId });
            }



            // Этот цикл добавляет команды в матчи

            for (int i = 0; i < numberOfTeams / 2; i++)
            {
                UpperBranch[i].Participants.Add(tournamentTeams[i]);
                UpperBranch[i].Participants.Add(tournamentTeams[i + 1]);
            }

            foreach (Match match in LowerBranch)
            {
                match.Participants = new List<TournamentTeam>();
            }

            // Этот цикл проставляет NextMatchNumber для верхней сетки
            {
                int upStep = numberOfTeams / 2;
                for (int i = 0; i < UpperBranch.Count; i += 2)
                {

                    UpperBranch[i].NextMatchNumber = i + 1 + upStep;
                    UpperBranch[i + 1].NextMatchNumber = i + 1 + upStep;
                    upStep -= 1;
                }
            }
            // Проставляются раунды для верхней сетки
            {
                int roundStep = numberOfTeams / 2;
                int roundNumber = 1;
                for (int i = 0; i < UpperBranch.Count; i += roundStep * 2)
                {
                    Round round = new Round
                    {
                        RoundNumber = roundNumber,
                        RoundType = tournament.PreFinalRoundType
                    };
                    for (int j = 0; j < roundStep; j++)
                    {

                        UpperBranch[i + j].Round = round;
                    }
                    roundStep = roundStep / 2;
                    if (roundStep == 0)
                    {
                        UpperBranch[i + 1].Round =  new Round
                        {
                            RoundNumber = roundNumber+1,
                            RoundType = tournament.FinalRoundType
                        };
                        
                        UpperBranch[^2].Round.RoundType = tournament.FinalRoundType;
                        break;
                    }
                    roundNumber++;
                }
            }

            // Проставляются NextMatchNumber для нижней сетки
            {
                LowerBranch[LowerBranch.Count - 1].NextMatchNumber = numberOfTeams;
                LowerBranch[LowerBranch.Count - 2].NextMatchNumber = numberOfTeams * 2 - 2;
                int lowStep = 2;
                int p = 0;
                int o = 0;
                int counter = 1;
                int c = 0;
                for (int i = LowerBranch.Count - 3; i >= 0; i -= o)
                {
                    p = 0;
                    o = 0;
                    c = 0;
                    counter = 1;

                    if (counter == 1)
                    {
                        for (int j = 0; j < lowStep; j++)
                        {
                            if (j != 0 && j % 2 == 0) { c++; }
                            LowerBranch[i - j].NextMatchNumber = LowerBranch[i + lowStep / 2 - c].MatchNumber;
                            p = j + 1;
                            o++;
                        }
                        counter++;
                    }
                    if (counter == 2)
                    {
                        for (int k = 0; k < lowStep; k++)
                        {
                            LowerBranch[i - p - k].NextMatchNumber = LowerBranch[i - p - k + lowStep].MatchNumber;
                            o++;
                        }
                        lowStep *= 2;
                    }
                }
            }

            // Проставляются LoserMatchNumber для верхней сетки
            {
                for (int i = 0; i < numberOfTeams / 4; i++)
                {
                    UpperBranch[i * 2].NextLooserMatchNumber = LowerBranch[i].MatchNumber;
                    UpperBranch[i * 2 + 1].NextLooserMatchNumber = LowerBranch[i].MatchNumber;
                }

                int counter;
                int step = numberOfTeams / 4;
                int numberLW = numberOfTeams / 4;
                int o;
                for (int i = numberOfTeams / 2; i < numberOfTeams - 1; i += o)
                {
                    counter = 1;
                    o = 0;
                    for (int j = 0; j < step; j++)
                    {
                        if (counter == 1)
                        {
                            UpperBranch[i + j].NextLooserMatchNumber = LowerBranch[numberLW].MatchNumber;
                            numberLW++;
                            o++;
                            if (j == step - 1)
                            {
                                counter++;
                                step /= 2;
                            }
                        }

                        if (counter == 2)
                        {
                            numberLW += step;
                        }
                    }
                }
            }

            UpperBranch[^1].NextMatchNumber = null;
            UpperBranch[^1].NextLooserMatchNumber = null;

            // Проставляются раунды для нижней сетки
            {
                int roundStep = numberOfTeams / 2;
                int roundNumber = 1;
                for (int i = 0; i < LowerBranch.Count; i += roundStep * 2)
                {
                    Round round1 = new Round
                    {
                        RoundNumber = roundNumber,
                        RoundType = tournament.PreFinalRoundType
                    };

                    for (int j = 0; j < roundStep / 2; j++)
                    {
                        LowerBranch[i + j].Round = round1;
                    }
                    Round round2 = new Round
                    {
                        RoundNumber = roundNumber+1,
                        RoundType = tournament.PreFinalRoundType
                    };
                    for (int p = roundStep / 2; p < roundStep; p++)
                    {
                        LowerBranch[i + p].Round = round2;
                    }
                    roundStep = roundStep / 2;
                    if (roundStep == 0)
                    {
                        LowerBranch[i + 1].Round = new Round
                        {
                            RoundNumber = roundNumber + 1,
                            RoundType = tournament.FinalRoundType
                        };
                        break;
                    }
                    roundNumber += 2;
                }
                LowerBranch[^1].Round.RoundType = tournament.FinalRoundType;
            }



            tournament.Bracket.Matches.AddRange(UpperBranch);
            tournament.Bracket.Matches.AddRange(LowerBranch);

            await _context.SaveChangesAsync(CancellationToken.None);

        }

        public GroupStage CreateGroupStage(int numberOfGroups, int numberOfTeamInGroups)
        {
            GroupStage result = new GroupStage();
            return result;
        }

        public async Task CreateBracket(Tournament tournament)
        {
            if (tournament.BracketType == BracketType.SingleElimination)
            {

            }
        }


    }
}
