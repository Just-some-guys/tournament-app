using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Round: Entity
    {
        public RoundType RoundType { get; set; }
        public int RoundNumber { get; set; }

    }
}
