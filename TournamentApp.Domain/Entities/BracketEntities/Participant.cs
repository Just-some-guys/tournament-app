using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Participant
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public string Status { get; set; }
        public bool IsWinner { get; set; }
    }
}
