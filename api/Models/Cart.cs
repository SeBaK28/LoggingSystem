using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public float TotalPrice { get; set; }
        public User user { get; set; }
        public DateTime CartCreatedAt { get; set; } = DateTime.Now;
    }
}