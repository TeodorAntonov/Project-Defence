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
        private readonly UserManager<User> _userManager;

        public ProfileService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                WeightStarted = client.WeightStarted.HasValue ? client.WeightStarted.Value : 1,
                HeightStarted = client.HeightStarted.HasValue ? client.HeightStarted.Value : 0,
                TypeOfSport = client.TypeOfSport,
                SetGoals = client.SetGoals,
                Trainer = client.Trainer,
                WorkoutPlan = client.WorkoutPlan,
                CurrentAge = client.CurrentAge,
                CurrentHeight = client.CurrentHeight,
                CurrentWeight = client.CurrentWeight,
                ClientNotes = client.ClientNotes,
            };
        }

        public async Task UpdateUserProfile(User user, ProfileViewModel model)
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

            client.CurrentAge = model.CurrentAge;
            client.CurrentWeight = model.CurrentWeight;
            client.CurrentHeight = model.CurrentHeight;
            client.ClientNotes = model.ClientNotes;
            client.TypeOfSport = model.TypeOfSport;
            client.Trainer = model.Trainer;
            client.WorkoutPlan = model.WorkoutPlan;

            await _context.SaveChangesAsync();
        }

        private IEnumerable<SportViewModel> GetSports()
        => this._context.Sports.Select(s => new SportViewModel()
        {
            Id = s.Id,
            Name = s.Name,
        });
    }
}
