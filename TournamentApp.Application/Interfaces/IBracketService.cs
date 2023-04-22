using TournamentApp.Application.Models.Brackets;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Interfaces
{
    public interface IBracketService
    {
        public DoubleEliminationBracketDto GetDEModelDtoAuto();

        public DoubleEliminationBracket CreateDoubleEliminationBracket();

        public SingleEliminationBracket CreateSingleEliminationBracket();
        public void CreateDEModel(int ToutnamentId);

        public GroupStage CreateGroupStage(int numberOfGroups, int numberOfTeamInGroups);
        public void CreateBracket(Tournament tournament);
    }
}
