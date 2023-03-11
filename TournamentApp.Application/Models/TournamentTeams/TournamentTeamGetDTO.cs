using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.TournamentTeams
{
    public class TournamentTeamGetDTO: IMapFrom<TournamentTeam>
    {
        public int Id { get; set; }

        public int TeamId  { get; set; }

        public int TournamentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TournamentTeam, TournamentTeamGetDTO>()
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.TeamId, opt => opt.MapFrom(i => i.TeamId))
            .ForMember(_ => _.TournamentId, opt => opt.MapFrom(i => i.TournamentId));

        }
    }
}
