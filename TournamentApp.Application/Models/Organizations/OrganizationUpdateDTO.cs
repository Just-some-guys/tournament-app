using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Organizations
{
    public class OrganizationUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganizationUpdateDTO, Organization>()
            .ForMember(_ => _.Id, opt => opt.Ignore())
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Description, opt => opt.MapFrom(i => i.Description));

        }
    }
}
