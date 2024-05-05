using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace gridd.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullNameUser { get; set; }
        [Required]
        [StringLength(50)]
        public string NameUser { get; set; }
        [StringLength(100)]
        public string Patronymic { get; set; }
        [Range(17, 99)]
        public int Age { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressUser { get; set; }
        public byte[]? Img { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Pass { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<ReceivedGame> ReceivedGames { get; set; }
        public ICollection<ReceivedAchievement> ReceivedAchievements { get; set; }
    }
}
