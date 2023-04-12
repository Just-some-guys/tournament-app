using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Players
{
    public class PlayerPreviewDTO: IMapFrom<Player>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public PlayerRole Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerPreviewDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.UserName, opt => opt.MapFrom(i => i.User.Name))            
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Logo, opt => opt.MapFrom(i => i.User.Logo))
            .ForMember(_ => _.Role, opt => opt.MapFrom(i => i.Role));

        }
    }
}
