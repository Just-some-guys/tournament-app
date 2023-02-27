using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities
{
    public class Player: Entity
    {
        public string Name { get; set; }

        public Discipline Discipline { get; set; }

        public int DisciplineId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public string Rank { get; set; } // Не ясно какой тип данных использовать
        
    }
}
