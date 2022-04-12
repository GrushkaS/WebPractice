using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    internal class Categories
    {
        [Key]
        internal int CategoryId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        internal string? CategoryName { get; set; }
    }
}
