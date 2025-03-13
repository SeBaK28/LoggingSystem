using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Dtos.CartProducts
{
    public class AddCartProductToListDto
    {
        [MinLength(1)]
        public string? ProductName { get; set; }
        [Required]
        [Range(1, 100)]
        public int Pieces { get; set; }
    }
}