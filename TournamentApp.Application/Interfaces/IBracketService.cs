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
        public Task CreateDEModel(int ToutnamentId);

        public GroupStage CreateGroupStage(int numberOfGroups, int numberOfTeamInGroups);
        public Task CreateBracket(Tournament tournament);
    }
}
