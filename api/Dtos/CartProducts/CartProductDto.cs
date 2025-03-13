using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CartProducts
{
    public class CartProductDto
    {
        public string? ProductName { get; set; }
        public int Pieces { get; set; }
        public float PricePerPiece { get; set; }
    }
}