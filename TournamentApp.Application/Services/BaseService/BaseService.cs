using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.BaseService
{
    public class BaseService<TContextObject, TCreateDTO, TGetDTO, TUpdateDTO> 
        : IBaseService<TContextObject, TCreateDTO, TGetDTO, TUpdateDTO>
        where TContextObject : Entity 
        where TCreateDTO : class
        where TGetDTO : class
        where TUpdateDTO : class         
            
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;      

        public BaseService(
            ITournamentAppContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<int> CreateAsync(TCreateDTO dto)
        {          

            TContextObject entity = _mapper.Map<TContextObject>(dto);            
            
            _context.Set<TContextObject>().Add(entity);

            await _context.SaveChangesAsync(CancellationToken.None);

            return entity.Id;
        }

        public async Task<TContextObject> GetAsync(int id)
        {
            TContextObject entity = await _context.Set<TContextObject>().FirstOrDefaultAsync(_ => _.Id == id);

            return entity;
        }
        public async Task<TGetDTO> GetDTOAsync(int id)
        {
            TContextObject entity = await _context.Set<TContextObject>().FirstOrDefaultAsync(_ => _.Id == id);

            return _mapper.Map<TGetDTO>(entity);
        }

        public async Task RemoveAsync(int id)
        {
            TContextObject entity = await _context.Set<TContextObject>().FirstOrDefaultAsync(x => x.Id == id);
            
            if (entity == null)
            {
                throw new Exception();
            }
            _context.Set<TContextObject>().Remove(entity);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAsync(TUpdateDTO dto, int id)
        {            
            TContextObject entity = await _context.Set<TContextObject>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception();
            }

            entity = _mapper.Map(dto, entity);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
