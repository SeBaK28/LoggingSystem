using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Products;
using api.Models;

namespace api.Mapper
{
    public static class ProductsMapper
    {
        public static ProductDto GetProductDto(this Product prod)
        {
            return new ProductDto
            {
                ProductName = prod.ProductName,
                Price = prod.Price,
                AvailableQuantity = prod.AvailableQuantity
            };
        }

        public static Product NewProductDto(this ProductDto productDto)
        {
            return new Product
            {
                ProductName = productDto.ProductName,
                AvailableQuantity = productDto.AvailableQuantity,
                Price = productDto.Price
            };
        }
    }
}