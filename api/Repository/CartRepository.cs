using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Dtos.Cart;
using api.Dtos.CartProducts;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CartRepository : ICart
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IProductData _product;
        public CartRepository(ApplicationDbContext context, UserManager<User> userManager, IProductData product)
        {
            _context = context;
            _userManager = userManager;
            _product = product;
        }

        public async Task<Cart> AddProductToCartAsync(string userId, CartProductDto productDto)
        {
            var userCart = FindCartById(userId);
            if (userCart == null)
                return null;

            var getProd = await _context.cartProducts.FirstOrDefaultAsync(x => x.UserCartId == userCart.CartId);

            if (getProd == null)
                return null;

            var availableProducts = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productDto.ProductName);

            if (availableProducts == null)
                return null;

            if (availableProducts.AvailableQuantity < productDto.Pieces)
            {
                productDto.Pieces = availableProducts.AvailableQuantity;
            }

            await _context.cartProducts.AddAsync(new CartProduct() { ProductName = productDto.ProductName, Pieces = productDto.Pieces });

            await _context.SaveChangesAsync();
            return userCart;

        }

        public Cart FindCartById(string userId)
        {
            return _context.Carts.FirstOrDefault(x => x.UserId == userId);
        }

        public async Task<Cart> FindCartByUserIdAsync(string userId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }

    }
}