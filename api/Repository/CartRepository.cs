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
            _userManager = userManager;
            _context = context;
        }

        public async Task<Cart> FindCartByUserId(string userId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public Task<List<Cart>> GetAllProdFromCartAsync(string email)
        {
            throw new NotImplementedException();
        }
        /*
       public async Task<List<Cart>> GetAllProdFromCartAsync(User user)
       {
           var curretnUser = _userManager.GetUserId(user);



           //return await _context.Carts.ToListAsync();
       }*/
    }
}