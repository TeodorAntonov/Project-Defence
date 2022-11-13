using DataModels.Entities;
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

        public async Task<IEnumerable<ClientViewModel>> GetClientsAsync(User user)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer == null)
            {
                throw new Exception("There is no such Trainer! Go Back!");
            }

            return trainer.Clients.Select(c => new ClientViewModel()
            {
                Id = c.Id,
                ClientName = $"{c.User.FirstName} {c.User.LastName}",
                Age = c.CurrentAge,
                Weight = c.CurrentWeight,
                Height = c.CurrentHeight,
                TypeOfSport = c.TypeOfSport,
                WorkoutPlan = c.WorkoutPlan,
            });
        }

        public async Task<IEnumerable<ClientViewModel>> GetClientsRequestsAsync(User user)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer == null)
            {
                throw new Exception("There is no such Trainer! Go Back!");
            }

            return trainer.ClientsApplications.Select(c => new ClientViewModel() 
            {
                Id = c.Id,
                ClientName = $"{c.User.FirstName} {c.User.LastName}",
                Age = c.CurrentAge,
                Weight = c.CurrentWeight,
                Height = c.CurrentHeight,
            });
        }
    }
}
