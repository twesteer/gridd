using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string NameAchievement { get; set; }
        [Required]
        [StringLength(200)]
        public string DescriptionAchievement { get; set; }

        public int GameId { get; set; }
        public Games Game { get; set; }
    }
}
