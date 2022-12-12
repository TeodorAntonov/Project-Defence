using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;

using GymViewModel = DataModels.Models.GymViewModel;

namespace Services
{
    public class GymService : IGymService
    {
        private readonly ApplicationDbContext _context;
        public GymService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GymViewModel>> GetAllGymsAsync()
        {
            var gyms = await _context.Gyms.ToListAsync();

            return gyms.Select(g => new GymViewModel()
            {
                Id = g.Id,
                Name = g.Name,
                Address = g.Address,
                ImageUrl = g.ImageUrl != null ? $"/UploadedFiles/{g.ImageUrl}" : $"/UploadedFiles/empty_fitness.png"
            }).OrderBy(g => g.Name);
        }
    }
}
