using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Products;
using api.Models;

namespace api.Dtos.Cart
{
    public class CartDto
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ProductDto>? ProductsList { get; set; } = new List<ProductDto>();
    }
}