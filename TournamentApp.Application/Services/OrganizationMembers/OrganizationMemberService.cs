using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.OrganizationMembers;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.OrganizationMembers
{
    public class OrganizationMemberService : IOrganizationMemberService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public OrganizationMemberService(
            ITournamentAppContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrganizationMemberCreateDTO dto)
        {
            if(!string.IsNullOrEmpty(dto.Name))
            {
                throw new Exception("Имя не заполнено");
            }

            User user = _context.Users.FirstOrDefault(_=>_.Name==dto.Name);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            OrganizationMember organizationMember = _mapper.Map<OrganizationMember>(user);
            organizationMember.UserId = user.Id;

            _context.OrganizationMembers.Add(organizationMember);

            await _context.SaveChangesAsync(CancellationToken.None);

            return organizationMember.Id;
        }

        public async Task RemoveAsync(int id)
        {
            OrganizationMember organizationMember = _context.OrganizationMembers.FirstOrDefault(x => x.Id == id);
            if (organizationMember == null)
            {
                throw new Exception();
            }
            _context.OrganizationMembers.Remove(organizationMember);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
