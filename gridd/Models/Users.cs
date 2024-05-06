    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace gridd.Models
    {
        public class Users
        {
            public Users(string fullNameUser, string nameUser, string patronymic, int age, string phone, string addressUser, string img, string email, string pass, int countryId
                )
            {
                FullNameUser = fullNameUser;
                NameUser = nameUser;
                Patronymic = patronymic;
                Age = age;
                Phone = phone;
                AddressUser = addressUser;
                Img = img;
                Email = email;
                Pass = pass;
                CountryId = countryId;
 
            }


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
            public string Img { get; set; }
            [Required]
            [EmailAddress]
            [StringLength(500)]
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
