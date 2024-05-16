using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class CartItem
    {
        public int Id { get; set; } // Это будет первичный ключ
        [StringLength(50)]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string ProductImageUrl { get; set; }
        [StringLength(50)]
        public decimal ProductPrice { get; set; }
        [StringLength(50)]
        public int Quantity { get; set; }
        
    }
}
