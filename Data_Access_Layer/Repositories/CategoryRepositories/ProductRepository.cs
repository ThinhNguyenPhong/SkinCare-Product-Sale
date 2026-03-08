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
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            Console.WriteLine("Product added to DbSet, saving changes...");
            await _context.SaveChangesAsync();
            Console.WriteLine("Changes saved successfully.");
        }

        public async Task DeleteProductAsync(string productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Feedbacks)
                .ThenInclude(f => f.Account)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId)
        {
            throw new NotImplementedException();
        }
        public async Task ToggleStatusAsync(String id)
        {

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsActive = !product.IsActive; // Toggle status
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
