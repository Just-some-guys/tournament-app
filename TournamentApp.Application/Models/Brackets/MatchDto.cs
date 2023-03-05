using AutoMapper;
using TournamentApp.Application.Common.Mappings;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Models.Brackets;
public class MatchDto : IMapFrom<Match>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? NextMatchId { get; set; }
    public int? NextLooserMatchId { get; set; }
    public DateTime StartTime { get; set; }
    public string State { get; set; }
    public List<Participant> Participants { get; set; } = new List<Participant>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Match, MatchDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(m => m.MatchNumber))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(m => m.Name))
            .ForMember(dto => dto.State, opt => opt.MapFrom(m => m.State))
            .ForMember(dto => dto.NextMatchId, opt => opt.MapFrom(m => m.NextMatchNumber))
            .ForMember(dto => dto.NextLooserMatchId, opt => opt.MapFrom(m => m.NextLooserMatchNumber))
            .ForMember(dto => dto.Participants, opt => opt.MapFrom(m => m.Participants));
        
    }
}
