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


namespace UnitTests
{
    public class ClientServiceTests
    {
        private ClientService service;
        ApplicationDbContext context;
        public ClientServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new ClientService(context);
        }


        [Fact]
        public async Task ApplyForTrainer_ShouldReturn_True()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };
            Client client = new Client() { Id = 1, User = user3, UserId = "testClient2" };

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
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Clients.Add(client);
            context.Trainers.Add(trainer);

            context.SaveChanges();

            var result = await service.ApplyingForTrainerAsync(user3, 1);

            Assert.Equal(1, trainer.ClientsApplications.Count);
            Assert.True(result);
        }

        [Fact]
        public async Task ApplyForTrainer_TraineHasTheClientApplicationAlready_ShouldReturn_False()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };
            Client client = new Client() { Id = 1, User = user3, UserId = "testClient2" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
                ClientsApplications = new List<Client>()
                         {
                            client,
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Clients.Add(client);
            context.Trainers.Add(trainer);

            context.SaveChanges();

            var result = await service.ApplyingForTrainerAsync(user3, 1);

            Assert.Equal(1, trainer.ClientsApplications.Count);
            Assert.False(result);
        }

        [Fact]
        public async Task ApplyForTrainer_TraineWorkWithTheClientAlready_ShouldReturn_False()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };
            Client client = new Client() { Id = 1, User = user3, UserId = "testClient2" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
                Clients = new List<Client>()
                         {
                            client,
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Clients.Add(client);
            context.Trainers.Add(trainer);

            context.SaveChanges();

            var result = await service.ApplyingForTrainerAsync(user3, 1);

            Assert.Equal(1, trainer.Clients.Count);
            Assert.False(result);
        }

        [Fact]
        public async Task ApplyForTrainer_ClientDoesntExist_ThrowsExepction()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };
            Client client = new Client() { Id = 1, User = user3, UserId = "testClient2" };

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
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Clients.Add(client);
            context.Trainers.Add(trainer);

            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.ApplyingForTrainerAsync(user, 1));
        }

        [Fact]
        public async Task ApplyForTrainer_TrainertDoesntExist_ThrowsExepction()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            context.Users.Add(user);
            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.ApplyingForTrainerAsync(user, 1));
        }
    }
}
