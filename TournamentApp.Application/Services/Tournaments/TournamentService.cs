using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Tournaments
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(TournamentDTO dto)
        {
            Tournament tournament = _mapper.Map<Tournament>(dto);

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync(CancellationToken.None);

            return tournament.Id;
        }

        public async Task RemoveAsync(int id)
        {
            Tournament tournament = _context.Tournaments.FirstOrDefault(t => t.Id == id);
            if (tournament == null)
            {
                throw new Exception();
            }
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAsync(TournamentDTO dto, int id)
        {
            Tournament tournament = _context.Tournaments.FirstOrDefault(t => t.Id == id);
            if (tournament == null)
            {
                throw new Exception();
            }
            tournament = _mapper.Map<Tournament>(dto);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<TournamentGetDTO> GetAsync(int id)
        {
            Tournament tournament = _context.Tournaments.FirstOrDefault(t => t.Id == id);
            if (tournament == null)
            {
                throw new Exception();
            }

            return _mapper.Map<TournamentGetDTO>(tournament);
        }
    }
}
