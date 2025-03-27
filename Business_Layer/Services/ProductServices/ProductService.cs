using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.CategoryRepositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Layer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return _productRepository.GetAllProductsAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }

        public Task<Product> GetProductByIdAsync(string productId)
        {
            return _productRepository.GetProductByIdAsync(productId);
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId)
        {
            return _productRepository.GetProductsByCategoryIdAsync(categoryId);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }
        public async Task ToggleStatusAsync(String id)
        {
            await _productRepository.ToggleStatusAsync(id);
        }
    }
}
