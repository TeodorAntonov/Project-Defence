using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<User> _userManager;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
            //_userManager = userManager;
        }

        public async Task<ProfileViewModel> GetUserProfile(User user)
        {
            if (user == null)
            {
                throw new Exception("Something went wrong with you profile");
            }

            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(cl => cl.UserId == user.Id);

            if (client == null)
            {
                throw new Exception("Something went wrong with you client profile");
            }

            return new ProfileViewModel()
            {
                Id = client.Id,
                UserId = client.UserId,
                Name = $"{client.User.FirstName} {client.User.LastName}",
                AgeStarted = client.AgeStarted.HasValue ? client.AgeStarted.Value : 0,
                WeightStarted = client.WeightStarted.HasValue ? client.WeightStarted.Value : 0,
                HeightStarted = client.HeightStarted.HasValue ? client.HeightStarted.Value : 0,
                TypeOfSport = client.TypeOfSport,
                SetGoals = client.SetGoals,
                Trainer = await GetUserTrainer(client.TrainerId, client),
                WorkoutPlan = client.WorkoutPlan,
                CurrentAge = client.CurrentAge,
                CurrentHeight = client.CurrentHeight,
                CurrentWeight = client.CurrentWeight,
                ClientNotes = client.ClientNotes,
            };
        }

        public async Task UpdateUserProfile(User user, UpdateMyProfileViewModel model)
        {
            if (user == null)
            {
                throw new Exception("Something went wrong with you profile");
            }

            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(cl => cl.UserId == user.Id);


            if (client == null)
            {
                throw new Exception("Something went wrong with you client profile");
            }

            if (!GetSports().Any(s => s.Id == model.TypeOfSportId))
            {
                throw new Exception("Sport does not exist.");
            }

            client.CurrentAge = model.Age;
            client.CurrentWeight = model.Weight;
            client.CurrentHeight = model.Height;
            client.TypeOfSport = GetSports().FirstOrDefault(s => s.Id == model.TypeOfSportId).Name ?? null;
            //client.Trainer = model.Trainer;
            if (model.SetGoals != null)
            {
                client.SetGoals = model.SetGoals;
            }
            client.ClientNotes = client.ClientNotes + Environment.NewLine + "|| RECORD ON " + DateTime.UtcNow.ToString("dd/mm/yyy") + ": " + model.Notes;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<SportViewModel> GetSports()
        => this._context.Sports.Select(s => new SportViewModel()
        {
            Id = s.Id,
            Name = s.Name,
        });

        public async Task SetUserProfile(User user, SetMyProfileViewModel model)
        {

            if (user == null)
            {
                throw new Exception("Something went wrong with you profile");
            }

            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(cl => cl.UserId == user.Id);


            if (client == null)
            {
                throw new Exception("Something went wrong with you client profile");
            }

            client.AgeStarted = model.Age;
            client.WeightStarted = model.Weight;
            client.HeightStarted = model.Height;

            await _context.SaveChangesAsync();
        }

        public async Task ClearAllNotes(Client client)
        {
            client.ClientNotes = string.Empty;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainerWrokout(Client client)
        {
            var trainer = await _context.Trainers.FindAsync(client.TrainerId);

            if (trainer != null)
            {
                trainer.Clients.Remove(client);
            }

            client.WorkoutPlan = string.Empty;
            client.TrainerId = null;
            client.Trainer = null;
            await _context.SaveChangesAsync();
        }

        private async Task<string?> GetUserTrainer(int? trainerId, Client client)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == trainerId);

            if (trainer == null)
            {
                return null;
            }

            if (!trainer.Clients.Contains(client))
            {
                return null;
            }

            return trainer.Name;
        }
    }
}
