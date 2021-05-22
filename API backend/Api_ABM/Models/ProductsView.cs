using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api_ABM.Controllers
{
    public class ProductsView
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "The minimum length must be 2 and the maximum length 40")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity per unit is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The minimum length must be 2 and the maximum length 20")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "A price is required")]
        [Range(0.01, 1000000, ErrorMessage = "The price must be between 0.01 and 1000000")]
        public decimal Price { get; set; }
    }
}