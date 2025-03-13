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

        public static Cart CreateMapToCartDto(this CreateCartDto createDto)
        {
            return new Cart
            {
                CartId = createDto.CartId,
                UserId = createDto.UserId,
                CartCreatedAt = createDto.CreatedAt,
                ProductsList = createDto.ProductList.Select(x => x.NewCartProductDto()).ToList()
            };
        }

        public static CartProductDto GetProductFromCartDto(this CartProduct cartProduct)
        {
            return new CartProductDto
            {
                ProductName = cartProduct.ProductName,
                Pieces = cartProduct.Pieces,
                PricePerPiece = cartProduct.PrivePerPiece
            };
        }

        public static CartProduct NewCartProductDto(this NewCartProductDto productDto)
        {
            return new CartProduct
            {
                UserCartId = productDto.CartId,

            };
        }

        public static CartProduct AddProductToCartDto(this AddCartProductToListDto addProdDto)
        {
            return new CartProduct
            {
                ProductName = addProdDto.ProductName,
                Pieces = addProdDto.Pieces
            };
        }
    }
}