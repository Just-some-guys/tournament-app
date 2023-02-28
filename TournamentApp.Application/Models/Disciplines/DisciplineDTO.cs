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
    public class DisciplineDTO : IMapFrom<Discipline>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DisciplineDTO, Discipline>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name));
        }
    }
}
