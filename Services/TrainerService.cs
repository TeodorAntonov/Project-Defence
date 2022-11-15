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

            trainer.Clients = await _context.Clients.Include(c => c.User).Where(c => c.TrainerId == trainer.Id).ToListAsync();

            return trainer.Clients.Select(c => new ClientViewModel()
            {
                Id = c.Id,
                ClientName = $"{c.User.FirstName} {c.User.LastName}",
                Age = c.CurrentAge,
                Email = c.User.Email,
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

            trainer.ClientsApplications = await _context.Clients.Include(c => c.User).Where(c => c.TrainerId == trainer.Id).ToListAsync();

            return trainer.ClientsApplications.Select(c => new ClientViewModel()
            {
                Id = c.Id,
                ClientName = $"{c.User.FirstName} {c.User.LastName}",
                Email = c.User.Email,
                Age = c.CurrentAge,
                Weight = c.CurrentWeight,
                Height = c.CurrentHeight,
            });
        }
        public async Task DeleteRequestAsync(User user, int clientId)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer == null)
            {
                throw new ArgumentException("No such trainer Id.");
            }

            var client = await _context.Clients.FindAsync(clientId);

            if (client == null)
            {
                throw new ArgumentException("No such client Id.");
            }

            if (trainer.ClientsApplications.Any())
            {
                client.Trainer = null;
                client.TrainerId = null;
                trainer.ClientsApplications.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddClientAsync(User user, int clientId)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer == null)
            {
                throw new ArgumentException("No such trainer Id.");
            }

            var client = await _context.Clients.FindAsync(clientId);

            if (client == null)
            {
                throw new ArgumentException("No such client Id.");
            }

            if (trainer.ClientsApplications != null)
            {
                client.Trainer = trainer;
                client.TrainerId = trainer.Id;

                trainer.Clients.Add(client);
                trainer.ClientsApplications.Remove(client);

                await _context.SaveChangesAsync();
            }
        }
    }
}
