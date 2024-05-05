using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace gridd.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NameCategories { get; set; }
    }
}
