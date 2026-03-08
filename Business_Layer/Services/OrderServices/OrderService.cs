using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly SkincareManagementContext _context;

        public OrderService(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Include(o => o.Payments)
                .Where(o => o.AccountId == userId)
                .ToListAsync();
        }



        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
