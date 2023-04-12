namespace TournamentApp.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }       
        public User User { get; set; }
        public int UserId { get; set; }
        public string Rank { get; set; } // Не ясно какой тип данных использовать
        public PlayerRole Role { get; set; }

    }
}
