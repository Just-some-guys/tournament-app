using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Players
{
    public class PlayerUpdateDTO : IMapFrom<Player>
    {
        public string Name { get; set; }        


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlayerUpdateDTO, Player>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name));
        }
    }


}
