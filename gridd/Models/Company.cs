using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NameCompany { get; set; }
        [Required]
        public int NumberOfGames { get; set; }
        [Required]
        [Range(0.1, 5.0)]
        public float Rating { get; set; }

        public ICollection<Games> Games { get; set; }
    }
}
