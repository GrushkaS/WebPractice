using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    internal class Products
    {
        [Key]
        internal int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        internal string? Name { get; set; }    
        internal decimal Price { get; set; }
        [StringLength(60, MinimumLength = 4)]
        internal string? Description { get; set; }
        [Required]
        internal string? Category { get; set; }

    }
}
