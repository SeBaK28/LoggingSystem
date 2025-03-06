using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IUserData
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User?> GetByUserNameAsync(string name);
        Task<User?> UpdateAsync(string name, UpdateUserDto updateDto);
        Task<User?> DeleteAsync(string email, string password);
    }
}