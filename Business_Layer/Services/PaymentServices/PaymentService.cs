using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly SkincareManagementContext _context;

        public PaymentService(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
