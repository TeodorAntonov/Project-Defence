using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using ProjectDefence.Data;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public AdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddGymAsync(AddGymViewModel model)
        {
            var gym = new Gym()
            {
                Name = model.Name,
                Address = model.Address,
                ImageUrl = model.ImageUrl ?? null,
            };
            await _context.Gyms.AddAsync(gym);
            await _context.SaveChangesAsync();
        }
        public async Task AddTrainerAsync(AddTrainerViewModel model)
        {
            var trainer = new Trainer()
            {
                Name = model.Name,
                Email = model.Email,
                Telephone = model.Telephone,
                Experience = model.Experience,
                IsAvailable = model.IsAvailable == "Yes" ? true : false,
                ImageUrl = model.ImageUrl ?? null,

            };
            await _context.Trainers.AddAsync(trainer);
            await _context.SaveChangesAsync();
        }
        public async Task AddRolesToUsers(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.ClientRole, ConstantsRoles.TrainerRole });
        }
    }
}
