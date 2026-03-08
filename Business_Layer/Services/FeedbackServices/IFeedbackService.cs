using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.FeedbackServices
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task<IEnumerable<Feedback>> GetFeedbacksByProductIdAsync(string id);
        Task AddFeedbackAsync(Feedback feedback);
        Task RemoveFeedbackAsync(int id);
    }
}
