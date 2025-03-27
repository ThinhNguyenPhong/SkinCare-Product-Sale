using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly SkincareManagementContext _context;

        public NewsService(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task<News> AddNewsAsync(News news)
        {
            await _context.AddAsync(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await _context.News.Include(e => e.Employee).ToListAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _context.News.Include(e => e.Employee).FirstOrDefaultAsync(e => e.NewsId == id);
        }

        public async Task RemoveNewsAsync(int newsId)
        {
            var news = await GetNewsByIdAsync(newsId);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }

        public async Task<News> UpdateNewsAsync(News news)
        {
            _context.Update(news);
            await _context.SaveChangesAsync();
            return news;
        }
    }
}
