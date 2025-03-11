using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CartRepository : ICart
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public CartRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Cart> FindCartByUserId(string userId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<string>> GetAllProdFromCartAsync(string email)
        {
            var user = await FindCartByUserId(email);

            var lista = user.ProductsList.Select(x => x.ProductName).ToList();

            return lista;
        }
    }
}