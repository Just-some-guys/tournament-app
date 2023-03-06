using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class DoubleEliminationModel
    {
        public int Id { get; set; }
        public List<Match> UpperBranch { get; set; }

        public List<Match> LowerBranch { get; set; }
    }
}
