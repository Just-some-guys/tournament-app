using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
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

        public async Task GetUserTournaments(int userId)
        {
            var playerIds = _context.Players.Where(_ => _.UserId == userId).Select(_ => _.Id).ToList();
            

        }

        public async Task<List<TournamentGetDTO>> GetTournamentsAsync()
        {
            return await _context.Tournaments.ProjectTo<TournamentGetDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<TournamentGetDTO>> GetHistoryByUserIdAsync(int userId)
        {            
            List<int> playerIds = _context.Players.Where(p => p.UserId == userId).Select(_=>_.TeamId).ToList();

            List<TournamentGetDTO> tournaments = _context.Tournaments
                .Where(_=>_.TournamentTeams.Any(q=> playerIds.Any(o=>o==q.TeamId)))
                .ProjectTo<TournamentGetDTO>(_mapper.ConfigurationProvider).ToList();
            return tournaments;
        }

        public async Task<List<TournamentPreviewDTO>> GetFiltredTournamentsAsync(Discipline discipline, DateTime? startDate, DateTime? endDate, TournamentType? type)
        {
            var query = _context.Tournaments.AsQueryable();

            if (discipline != null)
            {
                query = query.Where(p => p.DisciplineId == discipline.Id);
            }
            if (startDate != null)
            {
                query = query.Where(_ => _.StartDate >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(_ => _.StartDate <= endDate);
            }
            if(type != null)
            {
                query = query.Where(_=>_.TournamentType == type);
            }

            List<TournamentPreviewDTO> result = query.ProjectTo<TournamentPreviewDTO>(_mapper.ConfigurationProvider).ToList();                   

            return result;
        }
    }
}
