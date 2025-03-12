using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CartProducts;
using api.Dtos.Products;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        //[Authorize]
        [Route("{email}")]
        public async Task<IActionResult> GetMyCart([FromRoute] string email)
        {
            var getUserCart = await _context.Carts.Include(x => x.ProductsList).FirstOrDefaultAsync(x => x.UserId == email);

            var getProductsFromCart = await _context.cartProducts.FirstOrDefaultAsync(x => x.UserCartId == getUserCart.CartId);

            return Ok(getUserCart.GetCartDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(string userId, [FromBody] CartProductDto productDto)
        {
            var getCart = await _cart.AddProductToCartAsync(userId, productDto);

            var getProducts = await _context.cartProducts.FirstOrDefaultAsync(x => x.UserCartId == getCart.CartId);

            if (getCart == null || getProducts == null)
                return NotFound();

            //getCart.TotalPrice += getProducts.PrivePerPiece;

            await _context.SaveChangesAsync();

            return Ok(getCart.GetCartDto());
        }
    }
}