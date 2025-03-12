using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserDataRepository : IUserData
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ICart _cart;

        public UserDataRepository(ApplicationDbContext context, UserManager<User> userManager, ICart cart)
        {
            _cart = cart;
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Contains(email));

            if (user == null)
            {
                return null;
            }

            var userCart = await _cart.FindCartByUserIdAsync(user.Id);

            _context.Users.Remove(user);
            _context.Carts.Remove(userCart);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByUserNameAsync(string name)
        {
            var user = _context.Users.FirstOrDefaultAsync(s => s.UserName.Contains(name));
            return await user;
        }

        public async Task<bool> isEmailExist(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email);
        }
    }
}