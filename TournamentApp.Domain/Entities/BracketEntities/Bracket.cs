using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Bracket: Entity
    {
        public BracketType BracketType { get; set; } // Single/Double Elimination

        public Branch UpperBranch { get; set; }
        public int UpperBranchId { get; set; }

        public Branch LowerBranch { get; set; } //если режим Single Elimination - то этот список пустой или null
        public int LowerBranchId { get; set; }

        public int TournamentId { get; set; }
    }
}
