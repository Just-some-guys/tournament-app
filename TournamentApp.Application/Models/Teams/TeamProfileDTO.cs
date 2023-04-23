using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Teams
{
    public class TeamProfileDTO: IMapFrom<Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string CaptainName { get; set; }
        public string Discipline { get; set; } // Вот здесь вопрос, в команде у нас нет ссылки на игру, она есть только у игроков 



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamPreviewDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.CaptainName, opt => opt.MapFrom(i => i.Players.FirstOrDefault(_=>_.Role==PlayerRole.Captain).Name));

        }
    }
}
