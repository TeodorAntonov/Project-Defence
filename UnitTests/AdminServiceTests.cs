using DataModels.Entities;
using ProjectDefence.Data;
using System.Linq;
using Services;
using System.Collections.Generic;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using DataModels.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

namespace UnitTests
{
    public class AdminServiceTests
    {
        private AdminService service;
        ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new AdminService(userManager, context, roleManager, _webHostEnvironment);
        }

        [Fact]
        public async Task AddGym_ShouldAddOneGymToAllGyms_ResultFourGyms_ThreeAreHardCoded()
        {
            AddGymViewModel gym = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };

            var beforeAdding = await context.Gyms.ToListAsync();

            Assert.Equal(3, beforeAdding.Count);

            await service.AddGymAsync(gym);

            var afterAdding = await context.Gyms.ToListAsync();

            Assert.Equal("Test", afterAdding.Last().Name);
            Assert.Equal(4, afterAdding.Last().Id);
        }

        [Fact]
        public async Task AddTrainer_ShouldAddOneGymToAllTrainers_Result_FiveTrainers_OthersAreHardCoded()
        {
            AddTrainerViewModel trainer = new AddTrainerViewModel()
            {
                Name = "Test",
                Email = "Test",
                Telephone = "Test"
            };

            var beforeAdding = await context.Trainers.ToListAsync();

            Assert.Equal(3, beforeAdding.Count);

            await service.AddTrainerAsync(trainer);

            var afterAdding = await context.Trainers.ToListAsync();

            Assert.Equal("Test", afterAdding.Last().Name);
            Assert.Equal(5, afterAdding.Last().Id);
        }


        [Fact]
        public async Task EditGym_ShouldReturnUdpatedGym_And_True()
        {
            AddGymViewModel gym = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };

            AddGymViewModel updated = new AddGymViewModel()
            {
                Name = "Updated",
                Address = "Updated"
            };

            await service.AddGymAsync(gym);
            var result = await service.EditGymAsync(4, updated);

            var gyms = await context.Gyms.ToListAsync();

            Assert.True(result);
            Assert.Equal(4, gyms.Last().Id);
            Assert.Equal("Updated", gyms.Last().Name);
            Assert.True(result);
        }

        [Fact]
        public async Task EditGym_WithInvalidGymData_ShouldReturn_False()
        {
            AddGymViewModel gym = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };

            AddGymViewModel updated = new AddGymViewModel()
            {
                Name = "Updated",
                Address = "Updated"
            };

            await service.AddGymAsync(gym);
            var result = await service.EditGymAsync(10, updated);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteGym_ShouldReturn_GymCollection_WithOneLess()
        {
            Gym gym = new Gym()
            {
                Id = 4,
                Name = "Name",
                Address = "Address"
            };

            context.Gyms.Add(gym);
            context.SaveChanges();

            var before = await context.Gyms.ToListAsync();
            Assert.Equal(4, before.Count());

            await service.DeleteGymAsync(4);

            var after = await context.Gyms.ToListAsync();

            Assert.Equal(3, after.Count());
        }

        [Fact]
        public async Task GetGym_ShouldReturn_Gym_WithCurrentId()
        {
            Gym gym = new Gym()
            {
                Id = 5,
                Name = "Name",
                Address = "Address"
            };

            context.Gyms.Add(gym);
            context.SaveChanges();

            var result = await service.GetGymById(5);

            Assert.NotNull(result);
            Assert.Equal(typeof(AddGymViewModel), result.GetType());
            Assert.Equal("Name", result.Name);
            Assert.Equal("Address", result.Address);
        }

        [Fact]
        public async Task DeleteGym_WithINvalidData_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteGymAsync(4));
        }

        [Fact]
        public async Task GetTrainer_ShouldReturn_Trainer_WithCurrentId()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var result = await service.GetTrainerById(1);
            var list = await context.Users.ToListAsync();

            Assert.NotEmpty(list);
            Assert.Equal("Name", result.Name);
            Assert.Equal("Test@mail.com", result.Email);
            Assert.Equal("12321311", result.Telephone);
            Assert.Equal("Yes", result.IsAvailable);
        }


        [Fact]
        public async Task GetTrainer_ShouldReturn_Trainer_WithCurrentId_IsAvailableShouldbe_No()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = false,
                UserId = "test",
                User = user,
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var result = await service.GetTrainerById(1);
            var list = await context.Users.ToListAsync();

            Assert.NotEmpty(list);
            Assert.Equal("Name", result.Name);
            Assert.Equal("Test@mail.com", result.Email);
            Assert.Equal("12321311", result.Telephone);
            Assert.Equal("No", result.IsAvailable);
        }

        [Fact]
        public async Task EditTrainer_ShouldReturn_True_AndTrainer_WithCurrentId_IsAvailableShouldbe_Yes()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 5,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = false,
                UserId = "test",
                User = user,
            };

            AddTrainerViewModel model = new AddTrainerViewModel()
            {
                Name = "Name2",
                IsAvailable = "Yes",
                Email = "Test@mail.com",
                Telephone = "12321311",
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var result = await service.EditTrainerAsync(5, model);

            Assert.True(result);
            Assert.Equal("Name2", trainer.Name);
            Assert.Equal("Test@mail.com", trainer.Email);

        }

        [Fact]
        public async Task EditTrainer_EditWithoutMail_ThrowsExcpetion()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 5,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = false,
                UserId = "test",
                User = user,
            };

            AddTrainerViewModel model = new AddTrainerViewModel()
            {
                Name = "Name2",
                IsAvailable = "Yes",
                Telephone = "12321311",
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.EditTrainerAsync(5, model));
        }

        [Fact]
        public async Task EditTrainer_EditWithoutTelephone_ThrowsExcpetion()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 5,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = false,
                UserId = "test",
                User = user,
            };

            AddTrainerViewModel model = new AddTrainerViewModel()
            {
                Name = "Name2",
                IsAvailable = "Yes",
                Email = "Test@mail.com",
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.EditTrainerAsync(5, model));
        }

        [Fact]
        public async Task EditTrainer_WithInvalidTrainerID_ShouldReturn_False()
        {

            AddTrainerViewModel model = new AddTrainerViewModel()
            {
                Name = "Name2",
                IsAvailable = "Yes",
                Email = "Test@mail.com",
                Telephone = "12321311",
            };
            var result = await service.EditTrainerAsync(6, model);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteTrainer_ShouldReturn_TrainerCollection_WithOneLess()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Trainer trainer = new Trainer()
            {
                Id = 5,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = false,
                UserId = "test",
                User = user,
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var before = await context.Trainers.ToListAsync();
            Assert.Equal(4, before.Count());

            await service.DeleteTrainerAsync(5);

            var after = await context.Trainers.ToListAsync();

            Assert.False(after.Contains(trainer));
            Assert.Equal(3, after.Count());
            Assert.True(before.Count() > after.Count());
        }

        [Fact]
        public async Task DeleteTrainer_InvalidTrainer_ThrowsExcpetion()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteTrainerAsync(5));
        }
    }
}
