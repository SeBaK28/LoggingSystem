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

        public UserDataRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Email == email);
            if (user.Roles == "Admin")
            {
                return null;
            }
            if (user.PasswordHash != password || user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
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

        public Task<User?> GetByUserNameAsync(string name, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> UpdateAsync(string name, UpdateUserDto updateDto)
        {
            var stock = await _context.Users.FirstOrDefaultAsync(s => s.Email == name);

            if (stock == null)
            {
                return null;
            }

            /*if (stock.PasswordHash != null)
            {
                stock.PasswordHash = updateDto.PasswordHash;
            }*/
            if (stock.UserName != null)
            {
                stock.UserName = updateDto.UserName;
            }
            if (stock.PhoneNumber != null)
            {
                stock.PhoneNumber = updateDto.PhoneNumber;
            }





            /*if (stock.UserName != null)
            {
                stock.UserName = updateDto.UserName;
            }
            if (stock.PhoneNumber != null)
            {
                stock.PhoneNumber = updateDto.PhoneNumber;
            }
            if (stock.PasswordHash != null)
            {
                stock.PasswordHash = updateDto.PasswordHash;
            }*/

            await _context.SaveChangesAsync();

            return stock;

        }
    }
}