using AutoMapper;
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

        public DoubleEliminationBracketDto GetDEModelAuto()
        {
            Tournament tournament = new Tournament(); // Должен передаваться в параметры

            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.
            List<TournamentTeam> teams = tournament.TournamentTeams;
            DoubleEliminationModel result = new DoubleEliminationModel();

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

        public DoubleEliminationModel GetDEModelAutoNew()
        {
            Tournament tournament = new Tournament(); // Должен передаваться в параметры

            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.
            List<TournamentTeam> teams = tournament.TournamentTeams;
            DoubleEliminationModel result = new DoubleEliminationModel();

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

            return result;
        }
    }
}
