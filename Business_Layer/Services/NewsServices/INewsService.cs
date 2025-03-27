using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.NewsServices
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(int id);
        Task<News> AddNewsAsync(News news);
        Task<News> UpdateNewsAsync(News news);
        Task RemoveNewsAsync(int newsId);
    }
}
