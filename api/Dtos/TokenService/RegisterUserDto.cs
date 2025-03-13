using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Cart;

namespace api.Dtos
{
    public class RegisterUserDto
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Tokens { get; set; }
        public string? Roles { get; set; }
        public CreateCartDto cart { get; set; }
    }
}