using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Disciplines
{
    public class DisciplineGetDTO : IMapFrom<Discipline>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Discipline, DisciplineGetDTO>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id));
        }
    }
}
