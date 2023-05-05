using AutoMapper;
using Microsoft.AspNetCore.Http;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Organizations
{
    public class OrganizationCreateDTO : IMapFrom<Organization>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string HeaderImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganizationCreateDTO, Organization>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Description, opt => opt.MapFrom(i => i.Description));

        }
    }
}
