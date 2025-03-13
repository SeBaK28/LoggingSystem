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
        [Authorize]
        public async Task<IActionResult> GetMyCart()
        {
            var getUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var getUserCart = await _context.Carts.Include(x => x.ProductsList).FirstOrDefaultAsync(x => x.UserId == getUserId);

            var getProductsFromCart = await _context.cartProducts.FirstOrDefaultAsync(x => x.UserCartId == getUserCart.CartId);

            return Ok(getUserCart.GetCartDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProductToCart([FromBody] AddCartProductToListDto productDto)
        {
            var getUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var getProductData = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productDto.ProductName);
            if (getProductData.AvailableQuantity <= 0)
            {
                return Conflict($"No product avaliable: {productDto.ProductName}");
            }

            var getCart = await _cart.AddProductToCartAsync(getUserId, productDto);

            if (getCart == null || getProductData == null)
                return NotFound();


            getCart.TotalPrice += getProductData.Price * productDto.Pieces;

            // if (getProductData.AvailableQuantity < productDto.Pieces)
            // {                                                            //jak zrobić zeby przy wykonaniu If zwracał tez wiadomosc
            //     await _productData.SubstractProducts(productDto);
            //     await _context.SaveChangesAsync();
            //     return Created($"We've got only {getProductData.AvailableQuantity} pieces", getCart.GetCartDto());
            // }
            await _productData.SubstractProducts(productDto);

            await _context.SaveChangesAsync();

            return Ok(getCart.GetCartDto());
        }

        //Delete Product from cart
        //Change value of Pieces
    }
}