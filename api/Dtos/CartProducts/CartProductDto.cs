using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CartProducts
{
    public class CartProductDto
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public int Pieces { get; set; }
    }
}