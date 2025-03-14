using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CartProducts;
using api.Dtos.Products;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductDataRepository : IProductData
    {
        private readonly ApplicationDbContext _context;
        public ProductDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddNewProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(string ProductName)
        {
            var prod = await FindProductByNameAsync(ProductName);
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return prod;
        }


        public async Task<Product> FindProductByNameAsync(string name) =>
            await _context.Products.FirstOrDefaultAsync(x => x.ProductName.Contains(name));

        public async Task<List<Product>> GetAllProdAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task SubstractProducts(AddCartProductToListDto product)
        {
            var getProductData = await FindProductByNameAsync(product.ProductName);

            getProductData.AvailableQuantity -= product.Pieces;
        }
    }
}