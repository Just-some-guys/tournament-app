using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Branch : Entity
    {
        public bool IsUpperBranch { get; set; }
        public List<Round> Rounds { get; set; }
    }

}
