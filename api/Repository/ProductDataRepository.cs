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

        public async Task<Product?> FindProductAsync(string name)
        {
            var find = await _context.Products.FirstOrDefaultAsync(x => x.ProductName.Contains(name));

            if (find == null)
                return null;

            return find;
        }

        public async Task<List<Product>> GetAllProdAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}