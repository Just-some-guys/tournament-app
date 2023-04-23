using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class GroupStage: Entity
    {
        public List<Group> Groups { get; set; }

        public Tournament Tournament { get; set; }

        public int TournamentId { get; set; }

    }
}
