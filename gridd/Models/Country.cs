using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace gridd.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NameCountry { get; set; }
    }
}
