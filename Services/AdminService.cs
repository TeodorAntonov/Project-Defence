using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminService(UserManager<User> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
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

        public async Task<IEnumerable<RoleToUserViewModel>> GetAllUsersAsync()
        {
            var rolesFromDatabase = _roleManager.Roles.ToArray();
            var roles = new List<string>();
            var users = await _userManager.Users.ToListAsync();
            var userRoles = await _context.UserRoles.ToListAsync();

            foreach (var role in rolesFromDatabase)
            {
                roles.Add(role.Id);
            }

            return users.Select(u => new RoleToUserViewModel()
            {
                Id = u.Id,
                FullName = $"{u.FirstName} {u.LastName}",
                UserName = u.UserName,
                Email = u.Email,
                Roles = RoleList(u).Result.ToList(),
            });
        }

        private async Task<List<string>> RoleList(User user)
        {
            var rolesFromDatabase = _roleManager.Roles.ToArray();
            var roles = new List<string>();
            var users = _userManager.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            var ilist = await _userManager.GetRolesAsync(user);

            var list = ilist.ToList();

            return list;
        }

        public async Task<bool> EditGymAsync(int gymId, AddGymViewModel model)
        {
            var gym = await _context.Gyms.FindAsync(gymId);

            if (gym != null)
            {
                gym.ImageUrl = model.ImageUrl;
                gym.Name = model.Name;
                gym.Address = model.Address;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task DeleteGymAsync(int gymId)
        {
            var gym = await _context.Gyms.FindAsync(gymId);

            if (gym == null)
            {
                throw new ArgumentException("No such gym Id.");
            }

            _context.Gyms.Remove(gym);
            await _context.SaveChangesAsync();
        }

        public async Task<AddTrainerViewModel> GetTrainerById(int trainerId)
        {
            var trainer = await _context.Trainers.FindAsync(trainerId);

            return new AddTrainerViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Experience = trainer.Experience, 
                ImageUrl = trainer.ImageUrl,
                Telephone = trainer.Telephone,
                IsAvailable = trainer.IsAvailable ? "Yes" : "No"
            };
        }

        public async Task<bool> EditTrainerAsync(int trainerId, AddTrainerViewModel model)
        {
            var trainer = await _context.Trainers.FindAsync(trainerId);

            if (trainer != null)
            {
                trainer.ImageUrl = model.ImageUrl;
                trainer.Name = model.Name;
                trainer.Email = model.Email;
                trainer.Experience = model.Experience;
                trainer.Telephone = model.Telephone;
                trainer.IsAvailable = model.IsAvailable == "Yes"? true : false;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task DeleteTrainerAsync(int trainerId)
        {
            var trainer = await _context.Trainers.FindAsync(trainerId);

            if (trainer == null)
            {
                throw new ArgumentException("No such trainer Id.");
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();
        }

        public async Task<AddGymViewModel> GetGymById(int gymId)
        {
            var gym = await _context.Gyms.FindAsync(gymId);

            return new AddGymViewModel()
            {
                Name = gym.Name,
                Address = gym.Address,
                ImageUrl = gym.ImageUrl,
            };
        }
    }
}
