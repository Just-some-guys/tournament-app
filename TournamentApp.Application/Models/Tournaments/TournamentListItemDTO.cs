using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Application.Services;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Tournaments
{
    public class TournamentListItemDTO:IMapFrom<Tournament>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TournamentType { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfTeams { get; set; }
        public string TournamentStatus { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tournament, TournamentListItemDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.TournamentType, opt => opt.MapFrom(i => Helper.GetTournamentType(i.TournamentType)))   // надо будет это поле заполнять отдельно
            .ForMember(_ => _.StartDate, opt => opt.MapFrom(i => i.StartDate))
            .ForMember(_ => _.NumberOfTeams, opt => opt.MapFrom(i => i.TournamentTeams.Count))
            .ForMember(_ => _.TournamentStatus, opt => opt.MapFrom(i => Helper.GetTournamentStatus(i.TournamentStatus)));  // непонятно откуда брать, у User нет поля с именем, есть только Hash

        }
    }
}
