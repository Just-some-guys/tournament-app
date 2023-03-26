namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Match : Entity
    {
        public int MatchNumber { get; set; }
        public string Name { get; set; }
        public Round Round { get; set; }
        public int RoundId { get; set; }
        public int? NextMatchNumber { get; set; }
        public int? NextLooserMatchNumber { get; set; }
        public DateTime StartTime { get; set; }
        public string State { get; set; } // ожадиние игры, игра в процессе, сыграна
        public List<Game> Games { get; set; } // количество игр зависит от типа раунда
        public List<Participant> Participants { get; set; }
        public Team Winner { get; set; }
        public int WinnerId { get; set; }
    }
}
