using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class LoggedInUserDto
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Tokens { get; set; }
    }
}