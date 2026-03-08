using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.FeedbackServices
{
    public class FeedbackService : IFeedbackService
    {
        private readonly SkincareManagementContext _context;

        public FeedbackService(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task AddFeedbackAsync(Feedback feedback)
        {
            await _context.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.Product)
                .Include(f => f.Account)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByProductIdAsync(string id)
        {
            return await _context.Feedbacks
                .Include(f => f.Product)
                .Include(f => f.Account)
                .Where(f => f.ProductId == id)
                .ToListAsync();
        }

        public async Task RemoveFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == id);
            if (feedback == null)
            {
                return;
            }
            _context.Remove(feedback);
            await _context.SaveChangesAsync();
        }
    }
}
