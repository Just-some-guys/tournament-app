using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Application.Models.Disciplines;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Application.Models.TournamentTeams;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Tournaments
{
    public class TournamentGetDTO : IMapFrom<Tournament>
    {
        public int CreatorId { get; set; }
        public DisciplineGetDTO Discipline { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Rules { get; set; }
        public string Prize { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string CommunicationAddres { get; set; }
        public int MinTeamNumber { get; set; }
        public int MaxTeamNumber { get; set; }
        public bool CheckIn { get; set; }
        public int MinutesUntilRegEnd { get; set; }
        public bool CanPlayerSetResult { get; set; }
        public bool ScreenResult { get; set; } = true;
        public TournamentType TournamentType { get; set; }
        public string TournamentParametres { get; set; }
        public bool Published { get; set; }
        public List<TournamentTeamGetDTO> Teams { get; set; }
        public string Game { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tournament, TournamentGetDTO>()
            .ForMember(_ => _.CreatorId, opt => opt.MapFrom(i => i.CreatorId))
            .ForMember(_ => _.Discipline, opt => opt.MapFrom(i => i.Discipline))
            .ForMember(_ => _.DisciplineId, opt => opt.MapFrom(i => i.DisciplineId))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Id, opt => opt.MapFrom(i => i.Id))
            .ForMember(_ => _.StartDate, opt => opt.MapFrom(i => i.StartDate))
            .ForMember(_ => _.EndDate, opt => opt.MapFrom(i => i.EndDate))
            .ForMember(_ => _.Rules, opt => opt.MapFrom(i => i.Rules))
            .ForMember(_ => _.Prize, opt => opt.MapFrom(i => i.Prize))
            .ForMember(_ => _.CommunicationType, opt => opt.MapFrom(i => i.CommunicationType))
            .ForMember(_ => _.CommunicationAddres, opt => opt.MapFrom(i => i.CommunicationAddres))
            .ForMember(_ => _.MinTeamNumber, opt => opt.MapFrom(i => i.MinTeamNumber))
            .ForMember(_ => _.MaxTeamNumber, opt => opt.MapFrom(i => i.MaxTeamNumber))
            .ForMember(_ => _.CheckIn, opt => opt.MapFrom(i => i.CheckIn))
            .ForMember(_ => _.MinutesUntilRegEnd, opt => opt.MapFrom(i => i.MinutesUntilRegEnd))
            .ForMember(_ => _.CanPlayerSetResult, opt => opt.MapFrom(i => i.CanPlayerSetResult))
            .ForMember(_ => _.ScreenResult, opt => opt.MapFrom(i => i.ScreenResult))
            .ForMember(_ => _.TournamentType, opt => opt.MapFrom(i => i.TournamentType))
            .ForMember(_ => _.TournamentParametres, opt => opt.MapFrom(i => i.TournamentParametres))
            .ForMember(_ => _.Published, opt => opt.MapFrom(i => i.Published))
            .ForMember(_ => _.Teams, opt => opt.MapFrom(i => i.TournamentTeams));

        }
    }
}
