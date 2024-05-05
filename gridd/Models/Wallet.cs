using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        [Required]
        public decimal Score { get; set; }
        [Required]
        [StringLength(50)]
        public string Currency { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
