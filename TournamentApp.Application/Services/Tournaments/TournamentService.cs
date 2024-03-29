﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Application.Services.BaseService;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Tournaments
{
    public class TournamentService : BaseService
        <Tournament, TournamentDTO, TournamentGetDTO, TournamentUpdateDTO>,
        ITournamentService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentAppContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }       

        public async Task GetUserTournaments(int userId)
        {
            var playerIds = _context.Players.Where(_ => _.UserId == userId).Select(_ => _.Id).ToList();


        }

        public async Task<List<TournamentPreviewDTO>> GetTournamentsAsync()
        {
            return await _context.Tournaments.ProjectTo<TournamentPreviewDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<TournamentGetDTO>> GetHistoryByUserIdAsync(int userId)
        {
            List<int> playerIds = _context.Players.Where(p => p.UserId == userId).Select(_ => _.TeamId).ToList();

            List<TournamentGetDTO> tournaments = _context.Tournaments
                .Where(_ => _.TournamentTeams.Any(q => playerIds.Any(o => o == q.TeamId)))
                .ProjectTo<TournamentGetDTO>(_mapper.ConfigurationProvider).ToList();
            return tournaments;
        }

        public async Task<List<TournamentPreviewDTO>> GetFiltredTournamentsAsync( DateTime? startDate, DateTime? endDate, TournamentType? type)
        {
            var query = _context.Tournaments.AsQueryable();


            if (startDate != null)
            {
                query = query.Where(_ => _.StartDate >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(_ => _.StartDate <= endDate);
            }
            if (type != null)
            {
                query = query.Where(_ => _.TournamentType == type);
            }

            List<TournamentPreviewDTO> result = await query.ProjectTo<TournamentPreviewDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return result;
        }

        public async Task<List<TournamentListItemDTO>> GetTournamentsItemDTO(int organizationId, TournamentStatus status)
        {
            List<TournamentListItemDTO> result = await _context.Tournaments
                .Where(_=>_.CreatorId==organizationId && _.TournamentStatus==status)
                .ProjectTo<TournamentListItemDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return result;
        }
    }
}
