using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
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
            DoubleEliminationModel result = new DoubleEliminationModel();

            List<Match> UpperBranch = new List<Match>();
            List<Match> LowerBranch = new List<Match>();

            int teamscount = 32; 

            List<Team> teams = _context.Teams.ToList();

            // Создаются матчи верхней сетки
            for (int i = 1; i <= teamscount; i++)
            {
                UpperBranch.Add(new Match { Id = i });
            }
            // Создаются матчи нижней сетки
            for (int matchId = teamscount + 1; matchId <= teamscount * 2 - 2; matchId++)
            {
                LowerBranch.Add(new Match { Id = matchId });
            }

            // Этот цикл добавляет команды в матчи
            for (int i = 0; i < teamscount / 2; i++)
            {
                for (int p = 0; p < teamscount; p += 2)
                {
                    //UpperBranch[i].Participants = new List<Participant>();
                    //UpperBranch[i].Participants.Add(new Participant { Team = teams[p] });
                    //UpperBranch[i].Participants.Add(new Participant { Team = teams[p + 1] });
                }
            }

            // Этот цикл проставляет NextMatchId для верхней сетки
            int upStep = teamscount / 2;
            for (int i = 0; i < UpperBranch.Count; i += 2)
            {
                UpperBranch[i].NextMatchId = i + 1 + upStep;
                UpperBranch[i + 1].NextMatchId = i + 1 + upStep;
                upStep -= 1;
            }

            // Этот цикл проставляет NextMatchId для нижней сетки
            int lowStep = teamscount / 4;
            for (int i = 0; i < LowerBranch.Count; i += teamscount / 4)
            {
                int c = 0;
                for (int p = 0; p < lowStep; p++)
                {
                    LowerBranch[i + p].NextMatchId = LowerBranch[i + p].Id + lowStep;
                    c++;
                }

                for (int o = c; o <= c + lowStep; o += 2)
                {
                    LowerBranch[i + o].NextMatchId = LowerBranch[i + o].Id + lowStep;
                    LowerBranch[i + o + 1].NextMatchId = LowerBranch[i + o].Id + lowStep;
                    lowStep -= 1;
                }
                i += teamscount / 4;
            }

            LowerBranch[LowerBranch.Count - 2].NextMatchId = LowerBranch[LowerBranch.Count - 1].Id;
            LowerBranch[LowerBranch.Count - 1].NextMatchId = UpperBranch[UpperBranch.Count - 1].Id;


            return result;

        }
    }
}
