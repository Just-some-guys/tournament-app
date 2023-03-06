namespace TournamentApp.Application.Models.Brackets;
public class DoubleEliminationBracketDto
{
    public List<MatchDto> Upper { get; set; }

    public List<MatchDto> Lower { get; set; }
}
