using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Tournaments
{
    public class TournamentPreviewDTO: IMapFrom<Tournament>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Prize { get; set; }
        public DateTime StartDate { get; set; }
        public string Creator { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tournament, TournamentPreviewDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Region, opt => opt.Ignore())   // надо будет это поле заполнять отдельно
            .ForMember(_ => _.Prize, opt => opt.MapFrom(i => i.Prize))
            .ForMember(_ => _.StartDate, opt => opt.MapFrom(i => i.StartDate))            
            .ForMember(_ => _.Creator, opt => opt.Ignore());  // непонятно откуда брать, у User нет поля с именем, есть только Hash

        }
    }
}
