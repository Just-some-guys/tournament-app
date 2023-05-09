using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Domain.Entities
{
    public class Tournament : Entity
    {
        public Organization Creator { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Rules { get; set; }
        public string Prize { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public int CommunicationTypeId { get; set; }
        public string CommunicationAddres { get; set; }
        public int MinTeamNumber { get; set; }
        public int MaxTeamNumber { get; set; }
        public bool CheckIn { get; set; }
        public int MinutesUntilRegEnd { get; set; } // Минуты до окончания Чек-ина
        public bool CanPlayerSetResult { get; set; } // Могут ли игроки добавлять результат матча
        public string Logo { get; set; }        
        public string Description { get; set; }
        public bool RegistrationClose { get; set; }
        public TournamentStatus TournamentStatus { get; set; }

        // Необходимость подтверждения результата матча скрином
        public bool ScreenResult { get; set; } = true;
        public TournamentType TournamentType { get; set; }
        public string TournamentParametres { get; set; }
        public bool Published { get; set; }
        public List<TournamentTeam> TournamentTeams { get; set; }
        public GroupStage GroupStage { get; set; }
        public Bracket Bracket { get; set; }
        public RoundType PreFinalRoundType { get; set; }
        public RoundType FinalRoundType { get; set; }
        public BracketType BracketType { get; set; } // Single/Double Elimination
        public int BracketId { get; set; }
    }
}
