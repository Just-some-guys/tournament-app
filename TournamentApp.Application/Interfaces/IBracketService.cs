using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Brackets;
using TournamentApp.Domain.Entities;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Application.Interfaces
{
    public interface IBracketService
    {
        public DoubleEliminationModel GetDEModel();

        public DoubleEliminationBracketDto GetDEModelAuto();

        public DoubleEliminationModel GetDEModelAutoNew();
        public void GetBracket();

    }
}
