using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.OrganizationMembers
{
    public class OrganizationMemberCreateDTO: IMapFrom<OrganizationMember>
    {
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationRole OrganizationRole { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganizationMemberCreateDTO, OrganizationMember>()
            .ForMember(_ => _.UserId, opt => opt.Ignore())
            .ForMember(_ => _.OrganizationId, opt => opt.MapFrom(i => i.OrganizationId))
            .ForMember(_ => _.OrganizationRole, opt => opt.MapFrom(i => i.OrganizationRole));

        }
    }
}
