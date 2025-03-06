using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Mapper
{
    public static class UserDataMapper
    {
        public static UserDto ToStockDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = user.Roles,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash
            };
        }

        public static User ToCreateUserDto(this CreateUserDto createDto)
        {
            return new User
            {
                Email = createDto.Email,
                UserName = createDto.UserName,
                PhoneNumber = createDto.PhoneNumber,
                //PasswordHash = createDto.PasswordHash
            };
        }
    }
}