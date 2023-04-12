using TournamentApp.Application.Models.Brackets;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Interfaces
{
    public interface IBracketService
    {
        public DoubleEliminationBracketDto GetDEModelAuto();

        public DoubleEliminationModel GetDEModelAutoNew();
    }
}
