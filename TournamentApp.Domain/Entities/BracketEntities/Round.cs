namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Round: Entity
    {
        public RoundType RoundType { get; set; }
        public int RoundNumber { get; set; }
    }
}
