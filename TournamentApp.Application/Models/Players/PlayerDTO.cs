using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Players
{
    public class PlayerDTO : IMapFrom<Player>
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlayerDTO, Player>()                
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.UserId, opt => opt.MapFrom(i => i.UserId));

        }
    }


}
