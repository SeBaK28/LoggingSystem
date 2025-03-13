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

        public async Task<Cart> AddProductToCartAsync(string userId, AddCartProductToListDto productDto)
        {
            var getCartData = await FindCartByUserIdAsync(userId);

            var availableProducts = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productDto.ProductName);

            if (availableProducts == null)
                return null;

            if (availableProducts.AvailableQuantity < productDto.Pieces)
            {
                productDto.Pieces = availableProducts.AvailableQuantity;
            }

            getCartData.ProductsList.Add(productDto.AddProductToCartDto());

            await _context.SaveChangesAsync();
            return getCartData;

        }

        public async Task<Cart> FindCartByUserIdAsync(string userId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }

    }
}