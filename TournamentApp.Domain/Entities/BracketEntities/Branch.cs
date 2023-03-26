using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Branch : Entity
    {       
       // public Bracket Bracket { get; set; }
       //public int BracketId { get; set; }
        public List<Match> Matches { get; set; }
    }

}
