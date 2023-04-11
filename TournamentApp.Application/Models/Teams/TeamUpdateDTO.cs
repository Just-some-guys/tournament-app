using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Teams
{
    public class TeamUpdateDTO : IMapFrom<Team>
    {
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public string Region { get; set; }        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TeamUpdateDTO, Team>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Region, opt => opt.Ignore());
        }
    }
}
