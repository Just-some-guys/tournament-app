namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Game : Entity
    {
        
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public TournamentTeam Winner { get; set; }
        public int WinnerId { get; set; }
        public string GameFromRiotAPI { get; set; } // поле для поиска игры в RiotAPI
    }
}
