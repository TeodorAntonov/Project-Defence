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
using Microsoft.AspNetCore.Hosting;

namespace UnitTests
{
    public class TrainerServiceTests
    {
        private TrainerService service;
        ApplicationDbContext context;
        private IWebHostEnvironment webHostEnvironment;


        public TrainerServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new TrainerService(context, webHostEnvironment);
        }

        [Fact]
        public async Task GetAllClientsOfTrainer_ShouldReturnAllClientsInTrainerClietsCollection()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"}
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Trainers.Add(trainer);
            context.SaveChanges();
            var result = await service.GetClientsAsync(user);

            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task GetAllClientsOfTrainer_ShouldReturnAllTwoClientsInTrainerClietsCollection()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                            new Client() { Id = 2, User = user2, UserId = "testClient2"}
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Trainers.Add(trainer);
            context.SaveChanges();
            var result = await service.GetClientsAsync(user);

            Assert.NotEmpty(result);
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public async Task GetAllClientsOfTrainer_ShouldReturnNegativeResult()
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
                Clients = new List<Client>()
            };

            context.Users.Add(user);
            context.Trainers.Add(trainer);
            context.SaveChanges();
            var result = await service.GetClientsAsync(user);

            Assert.Empty(result);
            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async Task GetAllClientsOfTrainer_ShouldReturnAllClientRequestsInTrainerClietsCollection_PostiveResult()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
                Clients = new List<Client>(),
                ClientsApplications = new List<Client>()
                         {
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                            new Client() { Id = 2, User = user2, UserId = "testClient2"}
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.SaveChanges();
            var result = await service.GetClientsRequestsAsync(user);

            Assert.NotEmpty(result);
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public async Task GetAllClientsOfTrainer_ShouldReturnAllClientRequestsInTrainerClietsCollection_NegativeResult()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };

            Trainer trainer = new Trainer()
            {
                Id = 1,
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
                Clients = new List<Client>(),
                ClientsApplications = new List<Client>()
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.SaveChanges();
            var result = await service.GetClientsRequestsAsync(user);

            Assert.Empty(result);
            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async Task GetAllTrainers_ShouldReturnAllTrainers_PositiveResult()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user1 = new User() { Id = "test1", FirstName = "Test1", LastName = "Testov1" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };

            Trainer trainer = new Trainer()
            {
                Name = "Name",
                Email = "Test@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test",
                User = user,
                Clients = new List<Client>(),
                ClientsApplications = new List<Client>()
            };

            Trainer trainer2 = new Trainer()
            {
                Name = "Name2",
                Email = "Test2@mail.com",
                Telephone = "12321311",
                IsAvailable = true,
                UserId = "test1",
                User = user1,
                Clients = new List<Client>(),
                ClientsApplications = new List<Client>()
            };

            context.Users.Add(user);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Trainers.Add(trainer);
            context.Trainers.Add(trainer2);
            context.SaveChanges();
            var result = await service.GetAllTrainersAsync();

            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 5);
        }

        [Fact]
        public async Task GetAllTrainers_ShouldReturnTHreeHardCodedTrainers_PositiveResult()
        {
            var result = await service.GetAllTrainersAsync();
            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 3);
        }

        [Fact]
        public async Task GetClientWorkout_ShouldReturnSameWorkoutAsInTheModel_Postive()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "testClient", LastName = "testClient" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                            new Client() { Id = 2, User = user2, UserId = "testClient2"}
                         },
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var testModel = new ClientViewModel() { Id = 1, WorkoutPlan = "Test Workout" };

            await service.SaveWorkoutAsync(user, 1, testModel);

            var result = trainer.Clients.First().WorkoutPlan;

            Assert.NotNull(result);
            Assert.Equal(result, "Test Workout");
        }

        [Fact]
        public async Task CreateWorkoutModelView_ShouldReturnClientNameViewAsInTheModel_Postive()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "First Name", LastName = "Last Name" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                            new Client() { Id = 2, User = user2, UserId = "testClient2"}
                         },
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var result = await service.CreateWorkoutAsync(user, 1);

            Assert.NotNull(result);
            Assert.Equal(result.ClientName, "First Name Last Name");
            Assert.Equal(result.Id, 1);
        }

        [Fact]
        public async Task DeleteRequest_ShouldReturnTheCountMinusOne_PostiveCase()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "First Name", LastName = "Last Name" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };
            User user4 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                            new Client() { Id = 2, User = user3, UserId = "testClient2"},
                            new Client() { Id = 3, User = user4, UserId = "testClient3" }
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var beforeDeletion = trainer.ClientsApplications.Count;
            Assert.Equal(beforeDeletion, 3);

            await service.DeleteRequestAsync(user, 3);

            var afterDeletion = trainer.ClientsApplications.Count;
            Assert.Equal(afterDeletion, 2);
        }

        [Fact]
        public async Task DeleteClient_ShouldReturnNoneCases_PostiveCase()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "First Name", LastName = "Last Name" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };
            User user4 = new User() { Id = "testClient3", FirstName = "testClient3", LastName = "testClient3" };

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
                            new Client() { Id = 1, User = user2, UserId = "testClient"},
                         }
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Trainers.Add(trainer);
            context.SaveChanges();

            var beforeDeletion = trainer.ClientsApplications;
            Assert.NotNull(beforeDeletion);
            Assert.Single(beforeDeletion);

            await service.DeleteRequestAsync(user, 1);

            var afterDeletion = trainer.ClientsApplications.Count;
            Assert.Empty(beforeDeletion);
            Assert.Equal(afterDeletion, 0);
        }

        [Fact]
        public async Task AddClient_ShouldReturnCountOne_PostiveCase()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "First Name", LastName = "Last Name" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };
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
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.Clients.Add(client);
            context.SaveChanges();

            var beforeDeletion = trainer.ClientsApplications;
            Assert.Empty(beforeDeletion);

            await service.AddClientAsync(user, 1);

            var afterDeletion = trainer.ClientsApplications.Count;
            Assert.Single(beforeDeletion);
            Assert.Equal(afterDeletion, 1);
        }

        [Fact]
        public async Task ThrowErrorException_ThereIsNoSuchClient()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };
            User user2 = new User() { Id = "testClient", FirstName = "First Name", LastName = "Last Name" };
            User user3 = new User() { Id = "testClient2", FirstName = "testClient2", LastName = "testClient2" };
            Client client = new Client() { Id = 2, User = user3, UserId = "testClient2" };

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
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Trainers.Add(trainer);
            context.Clients.Add(client);
            context.SaveChanges();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AddClientAsync(user, 1));
        }
    }
}