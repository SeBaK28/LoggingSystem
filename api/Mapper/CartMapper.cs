using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Cart;
using api.Dtos.CartProducts;
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
                ProductsList = cart.ProductsList.Select(x => x.GetProductFromCartDto()).ToList()
            };
        }

        public static CartProductDto GetProductFromCartDto(this CartProduct cartProduct)
        {
            return new CartProductDto
            {
                ProductName = cartProduct.ProductName,
                Pieces = cartProduct.Pieces,
            };
        }

        public static CartProduct AddProductToCartDto(this CartProductDto productDto)
        {
            return new CartProduct
            {
                ProductName = productDto.ProductName,
                Pieces = productDto.Pieces,
            };
        }
    }
}