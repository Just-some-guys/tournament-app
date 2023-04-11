using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Teams
{
    public class TeamDTO : IMapFrom<Team>
    {
        public string Name { get; set; }        
        public string Region { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TeamDTO, Team>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Region, opt => opt.MapFrom(i => i.Region))
            .ForMember(_ => _.Players, opt => opt.MapFrom(i => i.Players));

        }
    }
}
