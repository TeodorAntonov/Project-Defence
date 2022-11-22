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
    public class ApplicationFormServiceTests
    {
        private ApplicationFormService service;
        ApplicationDbContext context;
        public ApplicationFormServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new ApplicationFormService(context);
        }

        [Fact]
        public async Task GetAllExercises_ShouldReturnAllExercises_PositiveResult()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            ApplicationFormForTrainersViewModel testModel = new ApplicationFormForTrainersViewModel()
            {
                UserId = "Test",
                Name = "Test",
                Username = "Test",
                Email = "Test Mail",
                Telephone = "Test Phone",
                Description = "Description Test",
            };

            context.Users.Add(user);

            await service.CreateApplicationAsync(testModel, "test");

            var list = context.Applications.ToList();

            Assert.NotEmpty(list);
            Assert.Single(list);
            Assert.Equal(list.First().Id, 1);
            Assert.Equal(list.First().Name, "Test");
            Assert.Equal(list.First().Email, "Test Mail");
            Assert.Equal(list.First().Telephone, "Test Phone");
            Assert.Equal(list.First().Description, "Description Test");
        }
    }
}
