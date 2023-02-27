using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public string Icon { get; set; }        
        public Player Captain { get; set; }
        public int CaptainId { get; set; }
    }
}
