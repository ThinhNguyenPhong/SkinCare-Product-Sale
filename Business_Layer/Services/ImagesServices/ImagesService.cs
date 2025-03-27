using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.ImagesServices
{
    public class ImagesService : IImagesService
    {
        private readonly SkincareManagementContext _context;

        public ImagesService(SkincareManagementContext context)
        {
            _context = context;
        }

        public async Task SaveImagesAsync(Image image)
        {
            await _context.AddAsync(image);
            await _context.SaveChangesAsync();
        }
    }
}
