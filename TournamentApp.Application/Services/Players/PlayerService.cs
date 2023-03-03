using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Players;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Players
{
    public class PlayerService : IPlayerService
    {
        private readonly ITournamentAppContext _context;
        private readonly IRiotAPIService _riotAPIService;
        public IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerService(ITournamentAppContext context, IPlayerService playerService, IMapper mapper, IRiotAPIService riotAPIService)
        {
            _context = context;
            _playerService = playerService;
            _mapper = mapper;
            _riotAPIService = riotAPIService;
        }

        public async Task<int> CreateAsync(PlayerDTO dto)
        {
            if (_riotAPIService.CheckSummonerName(dto.Name) != true)
            {
                throw new Exception("Ошибка проверки имени пользователя через RiotAPI");
            }

            Player player = _mapper.Map<Player>(dto);

            player.Rank = _riotAPIService.GetSummonerRankAsync(player.Name).ToString(); // Не Уверен что это будет работать
            _context.Players.Add(player);
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

        public async Task UpdateAsync(PlayerDTO dto, int id)
        {
            if (_riotAPIService.CheckSummonerName(dto.Name) != true)
            {
                throw new Exception("Ошибка проверки имени пользователя через RiotAPI");
            }

            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }
            player = _mapper.Map<Player>(dto);
            player.Rank = _riotAPIService.GetSummonerRankAsync(player.Name).ToString(); // Не Уверен что это будет работать
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
