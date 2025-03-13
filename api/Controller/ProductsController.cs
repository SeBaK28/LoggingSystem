using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Products;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductData _product;
        private readonly ApplicationDbContext _context;
        public ProductsController(IProductData product, ApplicationDbContext context)
        {
            _context = context;
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var list = await _product.GetAllProdAsync();
            var listDto = list.Select(x => x.GetProductDto());
            return Ok(listDto);
        }

        //Role: StoreService
        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductDto productDto)
        {
            if (productDto.Price <= 0 || productDto.AvailableQuantity <= 0) //
            {
                return Conflict("You cannot enter value less or equal to 0");
            }
            var newProd = productDto.NewProductDto();
            await _product.AddNewProductAsync(newProd);

            return CreatedAtAction(nameof(GetAllProducts), new { id = newProd.ProductId }, newProd.GetProductDto());
        }


        //Role: StoreService
        [HttpPut]
        [Route("{name}/{quantityOfProduct}")]
        public async Task<IActionResult> AddQuantity([FromRoute] string name, int quantityOfProduct)
        {
            var product = await _product.FindProductAsync(name);

            if (product == null)
            {
                return BadRequest();
            }

            if (quantityOfProduct <= 0)
            {
                return Conflict("Quantity of product cannot be lower or equal 0");
            }

            product.AvailableQuantity += quantityOfProduct;

            await _context.SaveChangesAsync();

            return Ok(product.GetProductDto());
        }

        //Remove Product

    }
}