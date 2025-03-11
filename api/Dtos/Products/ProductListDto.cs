using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Products
{
    public class ProductListDto
    {
        public string? ProductName { get; set; }
        public int Pieces { get; set; }
        public float Price { get; set; }
    }
}