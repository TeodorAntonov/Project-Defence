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

namespace UnitTests
{
    public class ProfileServiceTests
    {
        private ProfileService service;
        private ApplicationDbContext context;

        public ProfileServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new ProfileService(context);
        }

        [Fact]
        public async Task ClearAllNotes_ShouldDeleteClientDiary()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            Assert.Equal("Test", client.ClientNotes);

            await service.ClearAllNotes(client);

            Assert.Empty(client.ClientNotes);
            Assert.Equal(null, client.WorkoutPlan);
        }


        [Fact]
        public async Task GetSports_ShouldReturnAllSportInTheCollection()
        {
            Sport test2 = new Sport() { Id = 6, Name = "Test2" };
            Sport test3 = new Sport() { Id = 7, Name = "Test3" };
            Sport test4 = new Sport() { Id = 8, Name = "Test4" };

            context.Sports.Add(test2);
            context.Sports.Add(test3);
            context.Sports.Add(test4);
            context.SaveChanges();

            var result = service.GetSports();

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count());
        }

        [Fact]
        public async Task SetUserProfile_ShouldUpdateClientAgeWeigthHeight()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            SetMyProfileViewModel model = new SetMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            await service.SetUserProfile(user, model);

            Assert.NotNull(client.AgeStarted);
            Assert.NotNull(client.WeightStarted);
            Assert.NotNull(client.HeightStarted);
            Assert.Equal(12, client.AgeStarted);
            Assert.Equal(12, client.WeightStarted);
            Assert.Equal(12, client.HeightStarted);
        }

        [Fact]
        public async Task SetUserProfile_WithInvalidUser_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            SetMyProfileViewModel model = new SetMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.SetUserProfile(user2, model));
        }

        [Fact]
        public async Task SetUserProfile_WithInvalidClient_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            SetMyProfileViewModel model = new SetMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.SetUserProfile(user, model));
        }


        [Fact]
        public async Task GetUserProfile_ShouldReturnClientPofiles()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            var model = await service.GetUserProfile(user);

            Assert.NotNull(model);
            Assert.Equal(typeof(ProfileViewModel), model.GetType());
            Assert.Equal(1, model.Id);
            Assert.Equal("Test Testov", model.Name);
            Assert.Equal("Test", model.ClientNotes);
            Assert.Equal(0, model.WeightStarted);
            Assert.Equal(0, model.AgeStarted);
            Assert.Equal(0, model.HeightStarted);
        }

        [Fact]
        public async Task GetUserProfile_WithInvalidUser_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            SetMyProfileViewModel model = new SetMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetUserProfile(user2));
        }

        [Fact]
        public async Task GetUserProfile_WithInvalidClient_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            SetMyProfileViewModel model = new SetMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetUserProfile(user));
        }

        [Fact]
        public async Task UpdateUserProfile_ShouldChangeClientPofiles_WithNewData()
        {
            Sport test1 = new Sport() { Id = 6, Name = "Test2" };

            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test", SetGoals = "test" };

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel() { Age = 12, Height = 12, Weight = 12, TypeOfSportId = 6, Notes = "Test2" };

            context.Users.Add(user);
            context.Clients.Add(client);
            context.Sports.Add(test1);

            context.SaveChanges();

            await service.UpdateUserProfile(user, model);

            Assert.Equal(1, client.Id);
            Assert.Equal("test", client.SetGoals);
            Assert.Equal("Test\r\n|| RECORD ON " + DateTime.UtcNow.ToString("dd/mm/yyy") + ": " + "Test2", client.ClientNotes);
            Assert.Equal(12, client.CurrentAge);
            Assert.Equal(12, client.CurrentHeight);
            Assert.Equal(12, client.CurrentWeight);
        }

        [Fact]
        public async Task UpdateUserProfile_WithInvalidUser_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);
            context.Clients.Add(client);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.UpdateUserProfile(user2, model));
        }

        [Fact]
        public async Task UpdateUserProfile_WithInvalidClient_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel() { Age = 12, Height = 12, Weight = 12 };

            context.Users.Add(user);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.UpdateUserProfile(user2, model));
        }

        [Fact]
        public async Task UpdateUserProfile_WithInvalidSport_ShouldThrowsError()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "test2", FirstName = "Test", LastName = "Testov" };

            Client client = new Client() { Id = 1, UserId = "test", User = user, ClientNotes = "Test" };

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel() { Age = 12, Height = 12, Weight = 12, TypeOfSportId = 10  };

            context.Users.Add(user);
            context.Users.Add(user);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.UpdateUserProfile(user, model));
        }
    }
}
