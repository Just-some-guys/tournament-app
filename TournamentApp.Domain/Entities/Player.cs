namespace TournamentApp.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public Team Team { get; set; }
        public Discipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Rank { get; set; }
        public int TeamId { get; set; }// Не ясно какой тип данных использовать
    }
}
