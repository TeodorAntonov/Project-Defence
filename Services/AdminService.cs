using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminService(UserManager<User> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddGymAsync(AddGymViewModel model)
        {
            var gym = new Gym()
            {
                Name = model.Name,
                Address = model.Address,
                ImageUrl = UploadedFileGym(model),
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
                ImageUrl = UploadeFileTrainer(model),
                UserId = model.UserId ?? null,
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
                if (gym.ImageUrl == null)
                {
                    gym.ImageUrl = UploadedFileGym(model);
                }
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

            if (trainer == null)
            {
                return null;
            }

            return new AddTrainerViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Experience = trainer.Experience,
                HasImageUrl = trainer.ImageUrl == $"/UploadedFiles/no_profile_img.png" || trainer.ImageUrl == null ? true : false,
                // ImageUrl = trainer.ImageUrl,
                Telephone = trainer.Telephone,
                IsAvailable = trainer.IsAvailable ? "Yes" : "No",
                UserId = trainer.UserId ?? null,
            };
        }

        public async Task<bool> EditTrainerAsync(int trainerId, AddTrainerViewModel model)
        {
            var trainer = await _context.Trainers.FindAsync(trainerId);

            if (trainer != null)
            {
                if (trainer.ImageUrl == null)
                {
                    trainer.ImageUrl = UploadeFileTrainer(model);
                }
                trainer.Name = model.Name;
                trainer.Email = model.Email;
                trainer.Experience = model.Experience;
                trainer.Telephone = model.Telephone;
                trainer.IsAvailable = model.IsAvailable == "Yes" ? true : false;
                trainer.UserId = model.UserId ?? null;

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

            if (gym == null)
            {
                return null;
            }

            return new AddGymViewModel()
            {
                Name = gym.Name,
                Address = gym.Address,
                HasImageUrl = gym.ImageUrl == $"/UploadedFiles/no_profile_img.png" || gym.ImageUrl == null ? true : false,
                //ImageUrl = gym.ImageUrl,
            };
        }

        public async Task<EditUserViewModel> GetUserById(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (client == null)
            {
                return null;
            }

            return new EditUserViewModel()
            {
                Name = $"{user.FirstName} {user.LastName}",
                AgeStarted = client.AgeStarted,
                Email = user.Email,
                CurrentAge = client.CurrentAge,
                WeightCurrent = client.CurrentWeight,
                WeightStarted = client.WeightStarted,
                HeightStarted = client.HeightStarted,
                HeightCurrent = client.CurrentHeight,
                Notes = client.ClientNotes,
                SetGoals = client.SetGoals,
                //Trainer = client.Trainer,
                WorkoutPlan = client.WorkoutPlan,
                TypeOfSport = client.TypeOfSport,
                IsAdministrator = client.IsAdministrator,
                IsTrainer = client.IsTrainer,
                IsWriter = client.IsWriter,
            };
        }

        public async Task<bool> EditUserAsync(string userId, EditUserViewModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (user != null || client != null)
            {
                user.Email = model.Email;
                client.AgeStarted = model.AgeStarted;
                client.CurrentAge = model.CurrentAge;
                client.WeightStarted = model.WeightStarted;
                client.CurrentWeight = model.WeightCurrent;
                client.HeightStarted = model.HeightStarted;
                client.CurrentHeight = model.HeightCurrent;
                client.SetGoals = model.SetGoals;
                //client.Trainer = model.Trainer;
                client.WorkoutPlan = model.WorkoutPlan;
                client.TypeOfSport = model.TypeOfSport;
                client.ClientNotes = model.Notes;
                client.IsAdministrator = model.IsAdministrator;
                client.IsTrainer = model.IsTrainer;
                client.IsWriter = model.IsWriter;

                if (client.IsAdministrator)
                {
                    await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.TrainerRole });
                }
                else
                {
                    await _userManager.RemoveFromRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.TrainerRole });
                }

                if (client.IsTrainer)
                {
                    await _userManager.AddToRoleAsync(user, ConstantsRoles.TrainerRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, ConstantsRoles.TrainerRole);
                }

                if (client.IsWriter)
                {
                    await _userManager.AddToRoleAsync(user, ConstantsRoles.WriterRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, ConstantsRoles.WriterRole);
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (user == null)
            {
                throw new ArgumentException("No such user Id.");
            }

            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
        }

        private string UploadeFileTrainer(AddTrainerViewModel trainer)
        {
            string fileName = null;

            if (trainer.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedFiles");
                fileName = Guid.NewGuid().ToString() + "_" + trainer.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    trainer.ImageUrl.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        private string UploadedFileGym(AddGymViewModel gym)
        {
            string fileName = null;

            if (gym.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedFiles");
                fileName = Guid.NewGuid().ToString() + "_" + gym.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    gym.ImageUrl.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
