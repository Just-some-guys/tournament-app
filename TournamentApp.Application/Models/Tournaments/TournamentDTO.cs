using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Models.Tournaments
{
    public class TournamentDTO : IMapFrom<Tournament>
    {
        public int CreatorId { get; set; }        
        public int DisciplineId { get; set; }
        public string Name { get; set; }
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TournamentDTO, Tournament>()
            .ForMember(_ => _.CreatorId, opt => opt.MapFrom(i => i.CreatorId))
            .ForMember(_ => _.DisciplineId, opt => opt.MapFrom(i => i.DisciplineId))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
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
            .ForMember(_ => _.TournamentParametres, opt => opt.MapFrom(i => i.TournamentParametres));

        }
    }
}
