using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Products
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public int AvailableQuantity { get; set; }
        public float Price { get; set; }
    }
}