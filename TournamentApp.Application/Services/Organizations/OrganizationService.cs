using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.OrganizationMembers;
using TournamentApp.Application.Models.Organizations;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ITournamentAppContext _context;
        private readonly IOrganizationMemberService _organizationMemberService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrganizationService(
            ITournamentAppContext context,
            IMapper mapper,
            IOrganizationMemberService organizationMemberService,
            IUserService userService
            )

        {
            _context = context;
            _mapper = mapper;
            _organizationMemberService = organizationMemberService;
            _userService = userService;
        }

        public async Task<int> CreateAsync(OrganizationCreateDTO dto)
        {
            Organization organization = _mapper.Map<Organization>(dto);

            organization.OrganizationMembers.Add(
                new OrganizationMember
                {                    
                    OrganizationRole = OrganizationRole.Owner,
                    UserId = _userService.GetCurrentUser().Id,
                });
            _context.Organizations.Add(organization);

            await _context.SaveChangesAsync(CancellationToken.None);

            return organization.Id;
        }

        public async Task RemoveAsync(int id)
        {
            Organization organization =  await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (organization == null)
            {
                throw new Exception();
            }
            _context.Organizations.Remove(organization);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAsync(OrganizationUpdateDTO dto)
        {
            Organization organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (organization == null)
            {
                throw new Exception();
            }
            organization = _mapper.Map(dto, organization);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
