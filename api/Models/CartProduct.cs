using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class CartProduct
    {
        public int CartProductId { get; set; }
        public int UserCartId { get; set; }
        public Cart cart { get; set; }
        public string? ProductName { get; set; }
        public int Pieces { get; set; }
        public float PrivePerPiece { get; set; }
    }
}