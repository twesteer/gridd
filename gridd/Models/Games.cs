using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Games
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NameGame { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        [StringLength(3)]
        public string AgeLimit { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberOfCopiesPurchased { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }

        public ICollection<Achievement> Achievements { get; set; }

        // Изменено с object на ICollection<ReceivedGame>
        public ICollection<ReceivedGame> ReceivedGames { get; set; }
    }
}
