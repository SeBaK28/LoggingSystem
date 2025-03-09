using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateUserDto
    {
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}