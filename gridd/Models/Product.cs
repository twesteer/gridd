using System.ComponentModel.DataAnnotations;

namespace gridd.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ImageUrl { get; set; }
        [StringLength(50)]
        public decimal Price { get; set; }
        
    }
}