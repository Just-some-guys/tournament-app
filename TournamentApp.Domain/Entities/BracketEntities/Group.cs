using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Group:Entity
    {
        public string Name { get; set; }
        public List<TournamentTeam> TournamentTeams { get; set; }
        public List<Match> Matches { get; set; }
    }
}
