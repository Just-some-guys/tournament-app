using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Organizations
{
    public class OrganizationGetDTO: IMapFrom<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationGetDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Logo, opt => opt.MapFrom(i => i.Logo))
            .ForMember(_ => _.Description, opt => opt.MapFrom(i => i.Description))
            .ForMember(_ => _.Banner, opt => opt.MapFrom(i => i.Banner));

        }
    }
}
