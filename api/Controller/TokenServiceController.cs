using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Dtos.Cart;
using api.Dtos.CartProducts;
using api.Dtos.TokenService;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/account")]
    [ApiController]
    public class TokenServiceController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _context;
        private readonly IUserData _userData;
        private readonly ICart _cart;
        public TokenServiceController(UserManager<User> userManager, SignInManager<User> signInManager,
        ITokenService tokenService, IUserData userData, ApplicationDbContext context,
        ICart cart)
        {
            _cart = cart;
            _context = context;
            _userData = userData;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userReq = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

            if (userReq == null)
                return Unauthorized("Wrong email address or password");

            var result = await _signInManager.CheckPasswordSignInAsync(userReq, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Wrong email address or password");

            return Ok(
                new LoggedInUserDto
                {
                    Email = userReq.Email,
                    UserName = userReq.UserName,
                    Tokens = _tokenService.CreateToken(userReq)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = createUserDto.ToCreateUserDto();

                if (await _userData.isEmailExist(createUserDto.Email) == true)
                {
                    return Conflict($"This email: {appUser.Email} is already in used");
                }

                var createdUser = await _userManager.CreateAsync(appUser, createUserDto.PasswordHash);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new RegisterUserDto
                            {
                                Email = appUser.Email,
                                UserName = appUser.UserName,
                                PhoneNumber = appUser.PhoneNumber,
                                Roles = appUser.Roles,
                                Tokens = _tokenService.CreateToken(appUser),
                                cart = new CreateCartDto
                                {
                                    CartId = appUser.userCart.CartId,
                                    UserId = appUser.Id,
                                    ProductList = new List<NewCartProductDto>()
                                }
                                // cart = new CartDto
                                // {
                                //     CartId = appUser.userCart.CartId,
                                //     UserId = appUser.Id,
                                //     ProductsList = new List<CartProductDto>
                                // }
                            }
                        );

                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            };

        }

        [HttpPut]
        [Route("{email}")]
        public async Task<IActionResult> Update([FromRoute] string email, [FromBody] UpdateUserDto updateDto)
        {
            var getUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (getUser == null)
            {
                return NotFound();
            }

            getUser.PhoneNumber = updateDto.PhoneNumber;
            getUser.UserName = updateDto.UserName;


            var updateUser = await _userManager.UpdateAsync(getUser);

            if (updateUser.Succeeded)
            {
                return Ok(getUser.ToStockDto());
            }
            else
            {
                return StatusCode(500, updateUser.Errors);
            }
        }

        [HttpPost("password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetDto)
        {
            var getUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == resetDto.Email);

            if (getUser == null)
            {
                return NotFound();
            }

            var token = _tokenService.CreateToken(getUser);


            var updatePassword = await _userManager.ChangePasswordAsync(getUser, resetDto.CurrentPassword, resetDto.NewPassword);

            if (updatePassword.Succeeded)
            {
                return Ok("Pomyslnie zmieniono haslo");
            }
            else
            {
                return BadRequest("Niepowodzenie");
            }
        }

        [HttpDelete]
        [Route("{email}/{password}")]
        public async Task<IActionResult> Delete([FromRoute] string email, [FromRoute] string password)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.Roles == "Admin")
            {
                return Unauthorized("Cannot Delete this account");
            }

            var isPasswdCorrect = await _signInManager.CanSignInAsync(user);

            if (isPasswdCorrect == false)
            {
                return Unauthorized("Wrong Password");
            }

            var deleteCart = await _cart.FindCartByUserIdAsync(user.Id);
            var deleteUser = await _userManager.DeleteAsync(user);
            _context.Carts.Remove(deleteCart);
            await _context.SaveChangesAsync();

            if (deleteUser.Succeeded)
            {
                return Ok("Account removed");
            }
            else
            {
                return BadRequest("Cannot delete this account");
            }

        }
    }
}