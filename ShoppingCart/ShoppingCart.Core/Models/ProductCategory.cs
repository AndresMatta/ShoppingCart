using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        public string Category { get; set; }
    }
}
