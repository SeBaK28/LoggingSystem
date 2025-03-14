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
        Task<Cart> AddProductToCartAsync(string Email, AddCartProductToListDto cartProductDto);
        Task<Cart> FindCartByUserIdAsync(string userId);
        Task<Cart> ChangeValueOfPiecesInCartAsync(string UserID, string ProductName, int Pieces);
    }
}