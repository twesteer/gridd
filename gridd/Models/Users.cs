using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Users
    {
        public Users(string fullNameUser, string nameUser, string patronymic, int age, string phone, string addressUser, string img, string email, string pass, int countryId)
        {
            if (fullNameUser.Length > 50)
                throw new ArgumentException("Длина никнейма не должна превышать 50 символов.", nameof(fullNameUser));

            if (!nameUser.All(char.IsLetter) || nameUser.Length > 25)
                throw new ArgumentException("Имя должно содержать только русские буквы и не превышать 25 символов.", nameof(nameUser));

            if (!string.IsNullOrEmpty(patronymic) && (!patronymic.All(char.IsLetter) || patronymic.Length > 25))
                throw new ArgumentException("Отчество должно содержать только русские буквы и не превышать 25 символов.", nameof(patronymic));

            if (age < 16 || age > 99)
                throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть в диапазоне от 17 до 99.");

            if (!phone.All(char.IsDigit) || phone.Length != 11)
                throw new ArgumentException("Телефон должен содержать 11 цифр и не содержать других символов.", nameof(phone));

            if (addressUser.Length > 50)
                throw new ArgumentException("Длина адреса не должна превышать 50 символов.", nameof(addressUser));

            if (email.Length > 25)
                throw new ArgumentException("Длина электронной почты не должна превышать 25 символов.", nameof(email));

            if (pass.Length < 8 || !pass.Any(char.IsUpper) || !pass.Any(char.IsDigit))
                throw new ArgumentException("Пароль должен содержать хотя бы 1 заглавную букву, 1 цифру и иметь длину не менее 8 символов.", nameof(pass));

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

        [Required]
        [Range(16, 99)]
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
