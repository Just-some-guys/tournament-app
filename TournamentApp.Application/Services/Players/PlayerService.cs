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
        public IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerService(ITournamentAppContext context, IPlayerService playerService, IMapper mapper)
        {
            _context = context;
            _playerService = playerService;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(PlayerDTO dto)
        {
            Player player = _mapper.Map<Player>(dto);
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
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }
            player = _mapper.Map<Player>(dto);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<PlayerDTO> GetAsync(int id)
        {
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                throw new Exception();
            }
            return _mapper.Map<PlayerDTO>(player);
        }
    }
}
