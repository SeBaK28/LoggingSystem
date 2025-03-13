using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CartProducts
{
    public class AddCartProductToListDto
    {
        public string? ProductName { get; set; }
        public int Pieces { get; set; }
    }
}