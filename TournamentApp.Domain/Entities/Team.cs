namespace TournamentApp.Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public string? Icon { get; set; }
        public Region Region { get; set; }
    }
}
