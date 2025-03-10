using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Cart;
using api.Models;

namespace api.Mapper
{
    public static class CartMapper
    {
        public static CartDto GetCartDto(this Cart cart)
        {
            return new CartDto
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,
                CreatedAt = cart.CartCreatedAt,
                ProductsList = cart.ProductsList.Select(x => x.GetProductDto()).ToList()
            };
        }

        public static Cart CreateNewCartDto(this CartDto cartDto)
        {
            return new Cart
            {
                UserId = cartDto.UserId
            };
        }
    }
}