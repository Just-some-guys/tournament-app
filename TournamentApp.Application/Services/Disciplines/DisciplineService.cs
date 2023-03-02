using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Disciplines;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Disciplines
{
    public class DisciplineService : IDisciplineService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public DisciplineService(ITournamentAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(DisciplineDTO dto)
        {
            Discipline discipline = _mapper.Map<Discipline>(dto);

            _context.Disciplines.Add(discipline);
            await _context.SaveChangesAsync(CancellationToken.None);
            return discipline.Id;
        }

        public async Task<DisciplineGetDTO> GetAsync(int id)
        {
            Discipline discipline = _context.Disciplines.FirstOrDefault(x => x.Id == id);
            if (discipline == null)
            {
                throw new Exception("Дисциплина не найдена");
            }
            return _mapper.Map<DisciplineGetDTO>(discipline);
        }

        public async Task RemoveAsync(int id)
        {
            Discipline discipline = _context.Disciplines.FirstOrDefault(x => x.Id == id);

            if (discipline == null)
            {
                throw new Exception("Дисциплина не найдена");
            }
            _context.Disciplines.Remove(discipline);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAsync(DisciplineDTO dto, int id)
        {
            Discipline discipline = _context.Disciplines.FirstOrDefault(x => x.Id == id);

            if (discipline == null)
            {
                throw new Exception("Дисциплина не найдена");
            }
            discipline = _mapper.Map<Discipline>(dto);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

    }
}
