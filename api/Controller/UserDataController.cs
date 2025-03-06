using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controller
{
    [Route("api/controller")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserData _userData;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserDataController(IUserData userData, ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
            _userData = userData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock = await _userData.GetAllAsync();
            var stockDto = stock.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> GetByName([FromRoute] string userName)
        {
            var stock = await _userData.GetByUserNameAsync(userName);
            if (stock == null)
            {
                return NotFound();
            }


            return Ok(stock.ToStockDto());
        }

        [HttpDelete]
        [Route("{email}/{password}")]
        public async Task<IActionResult> Delete([FromRoute] string email, [FromRoute] string password)
        {
            var stock = await _userData.DeleteAsync(email, password);
            if (stock == null)
            {
                return BadRequest("Email or Password is incorrect");
            }

            return NoContent();
        }
        /*
                [HttpPut]
                [Route("user/{email}")]
                public async Task<IActionResult> Update([FromRoute] string email, [FromBody] UpdateUserDto updateUserDto)
                {
                    var updateDto = await _userData.UpdateAsync(email, updateUserDto);

                    if (updateDto == null)
                    {
                        return NotFound();
                    }

                    return Ok(updateDto.ToStockDto());
                }

        [HttpPut]
        [Route("{email}")]
        public async Task<IActionResult> Update([FromRoute] string email, [FromBody] UpdateUserDto updateDto)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Contains(email));
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email ==email);

            if (user != null)
            {
                return NotFound();
            }

            var updateUser = await _userManager.UpdateAsync(user);

            if (updateUser.Succeeded)
            {
                return Ok(updateUser);
            }
            else
            {
                return StatusCode(500, updateUser.Errors);
            }
        }*/
    }
}