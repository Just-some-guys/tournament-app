using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.OrganizationMembers;
using TournamentApp.Application.Models.Organizations;
using TournamentApp.Application.Services.BaseService;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Organizations
{
    public class OrganizationService 
        : BaseService
            <Organization, OrganizationCreateDTO, OrganizationGetDTO, OrganizationUpdateDTO>,
            IOrganizationService
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
            ) : base(context, mapper)

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


        public async Task<List<UserOrganizationGetDTO>> GetUserOrganizations(int UserId)

        {
            User user = _context.Users.FirstOrDefault(_ => _.Id == UserId);

            List<UserOrganizationGetDTO> organizations = await _context.Organizations
                .Include(_ => _.OrganizationMembers.Where(_ => _.UserId == UserId))
                .Where(_ => _.OrganizationMembers.Any(u => u.UserId == UserId))
                .ProjectTo<UserOrganizationGetDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return organizations;
        }


    }
}
