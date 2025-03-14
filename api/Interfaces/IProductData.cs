using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CartProducts;
using api.Dtos.Products;
using api.Models;

namespace api.Interfaces
{
    public interface IProductData
    {
        Task<List<Product>> GetAllProdAsync();
        Task<Product> AddNewProductAsync(Product product);
        Task<Product?> FindProductByNameAsync(string name);
        Task SubstractProducts(AddCartProductToListDto product);
        Task<Product?> DeleteProduct(string ProductName);
    }
}