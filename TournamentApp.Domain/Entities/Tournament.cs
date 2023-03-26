using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Domain.Entities
{
    public class Tournament : Entity
    {
        public Organization Creator { get; set; }
        public int CreatorId { get; set; }
        public Discipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Rules { get; set; }
        public string Prize { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string CommunicationAddres { get; set; }
        public int MinTeamNumber { get; set; }
        public int MaxTeamNumber { get; set; }
        public bool CheckIn { get; set; }
        public int MinutesUntilRegEnd { get; set; } // Минуты до окончания Чек-ина
        public bool CanPlayerSetResult { get; set; } // Могут ли игроки добавлять результат матча

        // Необходимость подтверждения результата матча скрином
        public bool ScreenResult { get; set; } = true;
        public TournamentType TournamentType { get; set; }
        public string TournamentParametres { get; set; }
        public bool Published { get; set; }
        public List<TournamentTeam> TournamentTeams { get; set; }

        public Bracket Bracket { get; set; }
        public BracketType BracketType { get; set; }
        public int BracketId { get; set; }
    }
}
