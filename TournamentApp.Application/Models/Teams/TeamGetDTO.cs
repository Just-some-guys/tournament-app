using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Application.Models.Players;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Teams
{
    public class TeamGetDTO: IMapFrom<Team>
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public int Id { get; set; }
        public List<PlayerGetDTO> Players { get; set; }
        public string Icon { get; set; }
        public PlayerGetDTO Captain { get; set; }
        public int CaptainId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamGetDTO>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Region, opt => opt.MapFrom(i => i.Region))
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Players, opt => opt.MapFrom(i => i.Players))
            .ForMember(_ => _.Icon, opt => opt.MapFrom(i => i.Icon))
            .ForMember(_ => _.Captain, opt => opt.MapFrom(i => i.Captain))
            .ForMember(_ => _.CaptainId, opt => opt.MapFrom(i => i.CaptainId));
        }
    }
}
