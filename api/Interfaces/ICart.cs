using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICart
    {
        Task<List<Cart>> GetAllProdFromCartAsync(string email);
        Task<Cart> FindCartByUserId(string userId);
    }
}