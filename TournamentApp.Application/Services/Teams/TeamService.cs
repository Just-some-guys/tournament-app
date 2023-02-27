using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Team;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITournamentAppContext _context;
        public IPlayerService _playerService;
        private readonly IMapper _mapper;

        public TeamService(ITournamentAppContext context, IPlayerService playerService, IMapper mapper)
        {
            _context = context;
            _playerService = playerService;
            _mapper = mapper;
        }

        public async Task<int> Create(TeamCreateDTO DTO)
        {
            Team team = _mapper.Map<Team>(DTO);

            _context.Teams.Add(team);
            await _context.SaveChangesAsync(CancellationToken.None);

            return team.Id;
        }

        public async Task Remove(int Id)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.Id == Id);
            if(team == null)
            {
                throw new Exception();
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync(CancellationToken.None);
        
        }
    }
}
