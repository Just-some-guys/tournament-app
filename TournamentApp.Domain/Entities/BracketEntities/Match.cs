using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Match: Entity
    {
        public int MatchNumber { get; set; }
        public string Name { get; set; }
        public int NextMatchId { get; set; }
        public int NextMatchNumber { get; set; }
        public int NextLooserMatchId { get; set; }
        public int NextLooserMatchNumber { get; set; }
        public DateTime StartTime { get; set; }
        public string State { get; set; }
        public int NumberOfRound { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
