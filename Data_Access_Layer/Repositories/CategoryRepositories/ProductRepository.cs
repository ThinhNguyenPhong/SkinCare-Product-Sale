using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories.CategoryRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SkincareManagementContext _context;

        public ProductRepository(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            Console.WriteLine("Product added to DbSet, saving changes...");
            await _context.SaveChangesAsync();
            Console.WriteLine("Changes saved successfully.");
        }

        public Task DeleteProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
