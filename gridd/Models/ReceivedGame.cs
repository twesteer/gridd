namespace gridd.Models
{
    public class ReceivedGame
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public Games Game { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
