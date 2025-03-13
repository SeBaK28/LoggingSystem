using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CartProducts;

namespace api.Dtos.Cart
{
    public class CreateCartDto
    {
        public int CartId { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<NewCartProductDto>? ProductList { get; set; }
    }
}