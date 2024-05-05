namespace gridd.Models
{
    public class ReceivedAchievement
    {
        public int Id { get; set; }

        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
