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

        public DoubleEliminationModel GetDEModel()
        {
            Tournament tournament = new Tournament(); // Должен передаваться в параметры

            int numberOfTeams = 16;     // 8-16-32-64-128-256 и т.д.
            List<TournamentTeam> teams = tournament.TournamentTeams;
            DoubleEliminationModel result = new DoubleEliminationModel();

            List<Match> UpperBranch = new List<Match>();
            List<Match> LowerBranch = new List<Match>();

            // Создаются матчи верхней сетки
            for (int i = 1; i <= numberOfTeams; i++)
            {
                UpperBranch.Add(new Match { MatchNumber = i });
            }

            // Создаются матчи нижней сетки
            for (int matchId = numberOfTeams + 1; matchId <= numberOfTeams * 2 - 2; matchId++)
            {
                LowerBranch.Add(new Match { MatchNumber = matchId });
            }

            // Этот цикл добавляет команды в матчи
            for (int i = 0; i < numberOfTeams / 2; i++)
            {
                for (int p = 0; p < numberOfTeams; p += 2)
                {
                    //UpperBranch[i].Participants = new List<Participant>();
                    //UpperBranch[i].Participants.Add(new Participant { Team = teams[p] });
                    //UpperBranch[i].Participants.Add(new Participant { Team = teams[p + 1] });
                }
            }

            // Этот цикл проставляет NextMatchId для верхней сетки
            int upStep = numberOfTeams / 2;
            for (int i = 0; i < UpperBranch.Count; i += 2)
            {
                UpperBranch[i].NextMatchNumber = i + 1 + upStep;
                UpperBranch[i + 1].NextMatchNumber = i + 1 + upStep;
                upStep -= 1;
            }

            // Для 16 команд
            if (numberOfTeams == 16)
            {
                LowerBranch[0].NextMatchNumber = 21;
                LowerBranch[1].NextMatchNumber = 22;
                LowerBranch[2].NextMatchNumber = 23;
                LowerBranch[3].NextMatchNumber = 24;

                LowerBranch[4].NextMatchNumber = 25;
                LowerBranch[5].NextMatchNumber = 25;
                LowerBranch[6].NextMatchNumber = 26;
                LowerBranch[7].NextMatchNumber = 26;

                LowerBranch[8].NextMatchNumber = 27;
                LowerBranch[9].NextMatchNumber = 28;

                LowerBranch[10].NextMatchNumber = 29;
                LowerBranch[11].NextMatchNumber = 29;

                LowerBranch[12].NextMatchNumber = 30;

                LowerBranch[13].NextMatchNumber = 16;

                UpperBranch[0].NextLooserMatchNumber = 17;
                UpperBranch[1].NextLooserMatchNumber = 17;
                UpperBranch[2].NextLooserMatchNumber = 18;
                UpperBranch[3].NextLooserMatchNumber = 18;
                UpperBranch[4].NextLooserMatchNumber = 19;
                UpperBranch[5].NextLooserMatchNumber = 19;
                UpperBranch[6].NextLooserMatchNumber = 20;
                UpperBranch[7].NextLooserMatchNumber = 20;

                UpperBranch[8].NextLooserMatchNumber = 24;
                UpperBranch[9].NextLooserMatchNumber = 23;
                UpperBranch[10].NextLooserMatchNumber = 22;
                UpperBranch[11].NextLooserMatchNumber = 21;

                UpperBranch[12].NextLooserMatchNumber = 27;
                UpperBranch[13].NextLooserMatchNumber = 28;

                UpperBranch[14].NextLooserMatchNumber = 30;
            }

            // Для 32 команд
            if (numberOfTeams == 32)
            {

                LowerBranch[0].NextMatchNumber = 41;
                LowerBranch[1].NextMatchNumber = 42;
                LowerBranch[2].NextMatchNumber = 43;
                LowerBranch[3].NextMatchNumber = 44;
                LowerBranch[4].NextMatchNumber = 45;
                LowerBranch[5].NextMatchNumber = 46;
                LowerBranch[6].NextMatchNumber = 47;
                LowerBranch[7].NextMatchNumber = 48;

                LowerBranch[8].NextMatchNumber = 49;
                LowerBranch[9].NextMatchNumber = 49;
                LowerBranch[10].NextMatchNumber = 50;
                LowerBranch[11].NextMatchNumber = 50;
                LowerBranch[12].NextMatchNumber = 51;
                LowerBranch[13].NextMatchNumber = 51;
                LowerBranch[14].NextMatchNumber = 52;
                LowerBranch[15].NextMatchNumber = 52;


                LowerBranch[16].NextMatchNumber = 53;
                LowerBranch[17].NextMatchNumber = 54;
                LowerBranch[18].NextMatchNumber = 55;
                LowerBranch[19].NextMatchNumber = 56;

                LowerBranch[20].NextMatchNumber = 57;
                LowerBranch[21].NextMatchNumber = 57;
                LowerBranch[22].NextMatchNumber = 58;
                LowerBranch[23].NextMatchNumber = 58;

                LowerBranch[24].NextMatchNumber = 59;
                LowerBranch[25].NextMatchNumber = 60;

                LowerBranch[26].NextMatchNumber = 61;
                LowerBranch[27].NextMatchNumber = 61;

                LowerBranch[28].NextMatchNumber = 62;

                LowerBranch[29].NextMatchNumber = 32;

                UpperBranch[0].NextLooserMatchNumber = 33;
                UpperBranch[1].NextLooserMatchNumber = 33;
                UpperBranch[2].NextLooserMatchNumber = 34;
                UpperBranch[3].NextLooserMatchNumber = 34;
                UpperBranch[4].NextLooserMatchNumber = 35;
                UpperBranch[5].NextLooserMatchNumber = 35;
                UpperBranch[6].NextLooserMatchNumber = 36;
                UpperBranch[7].NextLooserMatchNumber = 36;
                UpperBranch[8].NextLooserMatchNumber = 37;
                UpperBranch[9].NextLooserMatchNumber = 37;
                UpperBranch[10].NextLooserMatchNumber = 38;
                UpperBranch[11].NextLooserMatchNumber = 38;
                UpperBranch[12].NextLooserMatchNumber = 39;
                UpperBranch[13].NextLooserMatchNumber = 39;
                UpperBranch[14].NextLooserMatchNumber = 40;
                UpperBranch[15].NextLooserMatchNumber = 40;

                UpperBranch[16].NextLooserMatchNumber = 48;
                UpperBranch[17].NextLooserMatchNumber = 47;
                UpperBranch[18].NextLooserMatchNumber = 46;
                UpperBranch[19].NextLooserMatchNumber = 45;
                UpperBranch[20].NextLooserMatchNumber = 44;
                UpperBranch[21].NextLooserMatchNumber = 43;
                UpperBranch[22].NextLooserMatchNumber = 42;
                UpperBranch[23].NextLooserMatchNumber = 41;

                UpperBranch[24].NextLooserMatchNumber = 53;
                UpperBranch[25].NextLooserMatchNumber = 54;
                UpperBranch[26].NextLooserMatchNumber = 55;
                UpperBranch[27].NextLooserMatchNumber = 56;

                UpperBranch[28].NextLooserMatchNumber = 60;
                UpperBranch[29].NextLooserMatchNumber = 59;

                UpperBranch[30].NextLooserMatchNumber = 62;

            }


            // Для 64 команд
            if (numberOfTeams == 64)
            {

                LowerBranch[0].NextMatchNumber = 81;
                LowerBranch[1].NextMatchNumber = 82;
                LowerBranch[2].NextMatchNumber = 83;
                LowerBranch[3].NextMatchNumber = 84;
                LowerBranch[4].NextMatchNumber = 85;
                LowerBranch[5].NextMatchNumber = 86;
                LowerBranch[6].NextMatchNumber = 87;
                LowerBranch[7].NextMatchNumber = 88;
                LowerBranch[8].NextMatchNumber = 89;
                LowerBranch[9].NextMatchNumber = 90;
                LowerBranch[10].NextMatchNumber = 91;
                LowerBranch[11].NextMatchNumber = 92;
                LowerBranch[12].NextMatchNumber = 93;
                LowerBranch[13].NextMatchNumber = 94;
                LowerBranch[14].NextMatchNumber = 95;
                LowerBranch[15].NextMatchNumber = 96;

                LowerBranch[16].NextMatchNumber = 97;
                LowerBranch[17].NextMatchNumber = 97;
                LowerBranch[18].NextMatchNumber = 98;
                LowerBranch[19].NextMatchNumber = 98;
                LowerBranch[20].NextMatchNumber = 99;
                LowerBranch[21].NextMatchNumber = 99;
                LowerBranch[22].NextMatchNumber = 100;
                LowerBranch[23].NextMatchNumber = 100;
                LowerBranch[24].NextMatchNumber = 101;
                LowerBranch[25].NextMatchNumber = 101;
                LowerBranch[26].NextMatchNumber = 102;
                LowerBranch[27].NextMatchNumber = 102;
                LowerBranch[28].NextMatchNumber = 103;
                LowerBranch[29].NextMatchNumber = 103;
                LowerBranch[30].NextMatchNumber = 104;
                LowerBranch[31].NextMatchNumber = 104;

                LowerBranch[32].NextMatchNumber = 105;
                LowerBranch[33].NextMatchNumber = 106;
                LowerBranch[34].NextMatchNumber = 107;
                LowerBranch[35].NextMatchNumber = 108;
                LowerBranch[36].NextMatchNumber = 109;
                LowerBranch[37].NextMatchNumber = 110;
                LowerBranch[38].NextMatchNumber = 111;
                LowerBranch[39].NextMatchNumber = 112;

                LowerBranch[40].NextMatchNumber = 113;
                LowerBranch[41].NextMatchNumber = 113;
                LowerBranch[42].NextMatchNumber = 114;
                LowerBranch[43].NextMatchNumber = 114;
                LowerBranch[44].NextMatchNumber = 115;
                LowerBranch[45].NextMatchNumber = 115;
                LowerBranch[46].NextMatchNumber = 116;
                LowerBranch[47].NextMatchNumber = 116;

                LowerBranch[48].NextMatchNumber = 117;
                LowerBranch[49].NextMatchNumber = 118;
                LowerBranch[50].NextMatchNumber = 119;
                LowerBranch[51].NextMatchNumber = 120;

                LowerBranch[52].NextMatchNumber = 121;
                LowerBranch[53].NextMatchNumber = 121;
                LowerBranch[54].NextMatchNumber = 122;
                LowerBranch[55].NextMatchNumber = 122;

                LowerBranch[56].NextMatchNumber = 123;
                LowerBranch[57].NextMatchNumber = 124;

                LowerBranch[56].NextMatchNumber = 125;
                LowerBranch[57].NextMatchNumber = 125;

                LowerBranch[58].NextMatchNumber = 126;

                LowerBranch[57].NextMatchNumber = 64;



                UpperBranch[0].NextLooserMatchNumber = 65;
                UpperBranch[1].NextLooserMatchNumber = 65;
                UpperBranch[2].NextLooserMatchNumber = 66;
                UpperBranch[3].NextLooserMatchNumber = 66;
                UpperBranch[4].NextLooserMatchNumber = 67;
                UpperBranch[5].NextLooserMatchNumber = 67;
                UpperBranch[6].NextLooserMatchNumber = 68;
                UpperBranch[7].NextLooserMatchNumber = 68;
                UpperBranch[8].NextLooserMatchNumber = 69;
                UpperBranch[9].NextLooserMatchNumber = 69;
                UpperBranch[10].NextLooserMatchNumber = 70;
                UpperBranch[11].NextLooserMatchNumber = 70;
                UpperBranch[12].NextLooserMatchNumber = 71;
                UpperBranch[13].NextLooserMatchNumber = 71;
                UpperBranch[14].NextLooserMatchNumber = 72;
                UpperBranch[15].NextLooserMatchNumber = 72;
                UpperBranch[16].NextLooserMatchNumber = 73;
                UpperBranch[17].NextLooserMatchNumber = 73;
                UpperBranch[18].NextLooserMatchNumber = 74;
                UpperBranch[19].NextLooserMatchNumber = 74;
                UpperBranch[20].NextLooserMatchNumber = 75;
                UpperBranch[21].NextLooserMatchNumber = 75;
                UpperBranch[22].NextLooserMatchNumber = 76;
                UpperBranch[23].NextLooserMatchNumber = 76;
                UpperBranch[24].NextLooserMatchNumber = 77;
                UpperBranch[25].NextLooserMatchNumber = 77;
                UpperBranch[26].NextLooserMatchNumber = 78;
                UpperBranch[27].NextLooserMatchNumber = 78;
                UpperBranch[28].NextLooserMatchNumber = 79;
                UpperBranch[29].NextLooserMatchNumber = 79;
                UpperBranch[30].NextLooserMatchNumber = 80;
                UpperBranch[31].NextLooserMatchNumber = 80;

                UpperBranch[32].NextLooserMatchNumber = 96;
                UpperBranch[33].NextLooserMatchNumber = 95;
                UpperBranch[34].NextLooserMatchNumber = 94;
                UpperBranch[35].NextLooserMatchNumber = 93;
                UpperBranch[36].NextLooserMatchNumber = 92;
                UpperBranch[37].NextLooserMatchNumber = 91;
                UpperBranch[38].NextLooserMatchNumber = 90;
                UpperBranch[39].NextLooserMatchNumber = 89;
                UpperBranch[40].NextLooserMatchNumber = 88;
                UpperBranch[41].NextLooserMatchNumber = 87;
                UpperBranch[42].NextLooserMatchNumber = 86;
                UpperBranch[43].NextLooserMatchNumber = 85;
                UpperBranch[44].NextLooserMatchNumber = 84;
                UpperBranch[45].NextLooserMatchNumber = 83;
                UpperBranch[46].NextLooserMatchNumber = 82;
                UpperBranch[47].NextLooserMatchNumber = 81;

                UpperBranch[48].NextLooserMatchNumber = 105;
                UpperBranch[49].NextLooserMatchNumber = 106;
                UpperBranch[50].NextLooserMatchNumber = 107;
                UpperBranch[51].NextLooserMatchNumber = 108;
                UpperBranch[52].NextLooserMatchNumber = 109;
                UpperBranch[53].NextLooserMatchNumber = 110;
                UpperBranch[54].NextLooserMatchNumber = 111;
                UpperBranch[55].NextLooserMatchNumber = 112;

                UpperBranch[56].NextLooserMatchNumber = 120;
                UpperBranch[57].NextLooserMatchNumber = 119;
                UpperBranch[58].NextLooserMatchNumber = 118;
                UpperBranch[59].NextLooserMatchNumber = 117;

                UpperBranch[60].NextLooserMatchNumber = 123;
                UpperBranch[61].NextLooserMatchNumber = 124;

                UpperBranch[62].NextLooserMatchNumber = 126;
            }


            return result;
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
                result.UpperBranch.Add(new Match {Name = $"Match{i}", MatchNumber = i });
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
                    result.UpperBranch[i].Participants = new List<Participant>();
                }
            }

            foreach(Match match in result.LowerBranch)
            {
                match.Participants=new List<Participant>();
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
    }
}
