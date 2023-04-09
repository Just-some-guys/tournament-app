using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Application.Models.Disciplines;
using TournamentApp.Application.Models.Organizations;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Application.Models.TournamentTeams;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Tournaments
{
    public class TournamentGetDTO : IMapFrom<Tournament>
    {
        public OrganizationPreviewDTO Creator { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public DateTime StartDate { get; set; }
        public TournamentType TournamentType { get; set; }
        public string Rules { get; set; }
        public string Prize { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string CommunicationAddres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tournament, TournamentGetDTO>()
            .ForMember(_ => _.Creator, opt => opt.MapFrom(i => i.Creator))
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Region, opt => opt.Ignore())
            .ForMember(_ => _.StartDate, opt => opt.MapFrom(i => i.StartDate))
            .ForMember(_ => _.TournamentType, opt => opt.MapFrom(i => i.TournamentType))
            .ForMember(_ => _.Rules, opt => opt.MapFrom(i => i.Rules))
            .ForMember(_ => _.Prize, opt => opt.MapFrom(i => i.Prize))
            .ForMember(_ => _.CommunicationType, opt => opt.MapFrom(i => i.CommunicationType))
            .ForMember(_ => _.CommunicationAddres, opt => opt.MapFrom(i => i.CommunicationAddres));

        }
    }
}
