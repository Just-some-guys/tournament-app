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
    public class PlayerGetDTO : IMapFrom<Player>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerGetDTO>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Rank, opt => opt.MapFrom(i => i.Rank))
            .ForMember(_ => _.UserId, opt => opt.MapFrom(i => i.UserId));

        }
    }
}
