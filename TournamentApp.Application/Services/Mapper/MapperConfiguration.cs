using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Player;
using TournamentApp.Application.Models.Team;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Mapper
{
    public class MapperConfiguration: Profile
    {
        public MapperConfiguration()
        {
            this.CreateMap<PlayerCreateDTO, Player>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.DisciplineId, opt => opt.MapFrom(i => i.DisciplineId))
            .ForMember(_ => _.UserId, opt => opt.MapFrom(i => i.UserId));

            this.CreateMap<TeamCreateDTO, Team>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.CaptainId, opt => opt.MapFrom(i => i.CaptainId))
            .ForMember(_ => _.Players, opt => new List<Player>()); // Не уверен что это так работает
        }
    }
}
