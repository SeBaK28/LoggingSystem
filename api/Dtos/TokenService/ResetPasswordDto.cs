using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TokenService
{
    public class ResetPasswordDto
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}