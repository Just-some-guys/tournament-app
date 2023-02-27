using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Application.Models.Player
{
    public class PlayerCreateDTO
    {
        public string Name { get; set; }
        public int DisciplineId { get; set; }
        public int UserId { get; set; }
    }
}
