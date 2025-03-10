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
using Microsoft.AspNetCore.Authorization;
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
        public UserDataController(IUserData userData, ApplicationDbContext context)
        {
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

        //AsAdmin
        [HttpDelete]
        [Route("{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string email)
        {
            var user = await _userData.DeleteAsync(email);

            if (user == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}