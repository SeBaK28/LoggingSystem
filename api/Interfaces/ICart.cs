using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Cart;
using api.Dtos.CartProducts;
using api.Models;

namespace api.Interfaces
{
    public interface ICart
    {
        Task<Cart> AddProductToCartAsync(string Email, CartProductDto cartProductDto);
        Task<Cart> FindCartByUserIdAsync(string userId);
        Cart FindCartById(string userId);
    }
}