using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Products
{
    public class AddProductDto
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}