using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Products;
using api.Interfaces;
using api.Mapper;
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
        /*
                [HttpGet]
                public async Task<IActionResult> GetAllFromCart()
                {
                    var prod = await _cart.GetAllProdFromCartAsync();

                    var prodDto = prod.Select(s => s.GetCartDto());

                    return Ok(prodDto);
                }*/

    }
}