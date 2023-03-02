using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Players;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Players
{
    public class PlayerService : IPlayerService
    {
        private readonly ITournamentAppContext _context;
        private readonly IRiotAPIService _riotAPIService;
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public PlayerService(
            ITournamentAppContext context,
            IMapper mapper,
            IRiotAPIService riotAPIService,
            ITeamService teamService)
        {
            _context = context;
            _mapper = mapper;
            _riotAPIService = riotAPIService;
            _teamService = teamService;
        }

        public async Task<int> CreateAsync(PlayerDTO dto, int teamId)
        {
            Team team = await _teamService.GetAsync(teamId);

            if (await _riotAPIService.CheckSummonerNameAsync(dto.Name, team.Region) != true)
            {
                throw new Exception("Ошибка проверки имени пользователя через RiotAPI");
            }

            Player player = _mapper.Map<Player>(dto);

            player.Rank = await _riotAPIService.GetSummonerRankAsync(player.Name, team.Region); // Не Уверен что это будет работать

            _context.Players.Add(player);

            if (team.Players == null)
            {
                team.Players = new List<Player>();
            }

            team.Players.Add(player);

            await _context.SaveChangesAsync(CancellationToken.None);

            return player.Id;
        }

        public async Task RemoveAsync(int id)
        {
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }
            _context.Players.Remove(player);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAsync(PlayerUpdateDTO dto, int id)
        {
            Team team = await _teamService.GetByPlayerIdAsync(id);

            if (await _riotAPIService.CheckSummonerNameAsync(dto.Name, team.Region) != true)
            {
                throw new Exception("Ошибка проверки имени пользователя через RiotAPI");
            }

            Player player = _context.Players.Include(_=>_.User).FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }

            //player = _mapper.Map<Player>(dto);
            player.Name = dto.Name;
            player.Rank = await _riotAPIService.GetSummonerRankAsync(player.Name, team.Region); // Не Уверен что это будет работать
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<PlayerGetDTO> GetAsync(int id)
        {
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }

            return _mapper.Map<PlayerGetDTO>(player);
        }
    }
}
