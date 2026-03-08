using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.OrderServices
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }
}
