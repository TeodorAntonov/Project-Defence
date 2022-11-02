using DataModels.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;

namespace Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ApplicationDbContext _context;
        public TrainerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TrainerViewModel>> GetAllTrainersAsync()
        {
            var trainers = await _context.Trainers.ToListAsync();

            return trainers.Select(g => new TrainerViewModel()
            {
                Id = g.Id,
                Name = g.Name,
                Telephone = g.Telephone,
                Email = g.Email,
                IsAvailable = g.IsAvailable ? "Yes" : "No",
                Experience = g.Experience,
                ImageUrl = g.ImageUrl
            });
        }
    }
}
