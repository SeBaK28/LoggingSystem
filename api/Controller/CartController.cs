using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Products;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;
        private readonly IProductData _productData;
        private readonly ApplicationDbContext _context;

        public CartController(ICart cart, IProductData productData, ApplicationDbContext context)
        {
            _context = context;
            _productData = productData;
            _cart = cart;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyCart([FromBody] string email)
        {
            // var getName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // var getCart = await _cart.FindCartByUserId(getName);

            // var cartProduct = await _cart.GetAllProdFromCartAsync(getCart);

            // return Ok(cartProduct.ToList());

            var user = _cart.GetAllProdFromCartAsync(email);

            return Ok(user);


            // var role = User.FindFirst("Role")?.Value;

            // if (string.IsNullOrEmpty(getName) || string.IsNullOrEmpty(role))
            // {
            //     return Unauthorized("Dupa");
            // }

            // return Ok(new { UserId = getName, UserRole = role });
        }
    }
}