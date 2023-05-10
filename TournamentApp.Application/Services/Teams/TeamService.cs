using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Application.Services.BaseService;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Teams
{
    public class TeamService : BaseService
        <Team, TeamDTO, TeamGetDTO, TeamUpdateDTO>,
        ITeamService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public TeamService(ITournamentAppContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }               
          

        public async Task<Team> GetByPlayerIdAsync(int playerId)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Players.Any(_ => _.Id == playerId));

            if(team == null)
            {
                throw new Exception("Команда не найдена");
            }
            return team;
        }
    }
}
