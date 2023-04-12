namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Bracket : Entity
    {
        public BracketType BracketType { get; set; } // Single/Double Elimination
        public List<Match> Matches { get; set; }

        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
    }
}
