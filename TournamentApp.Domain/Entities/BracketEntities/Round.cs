using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Round: Entity
    {
        public int NumberOfStep { get; set; } // Не уверен что это нужно, при 16 командах будет 4 этапа, при 32 - 5 этапов и тд
        public List<Game> Games { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; }
    }
}
