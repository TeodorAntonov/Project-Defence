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
    public class AdminMailboxServiceTests
    {
        private AdminMailboxService service;
        private ApplicationDbContext context;
        public AdminMailboxServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new AdminMailboxService(context);
        }

        [Fact]
        public async Task GetAllUnCkeckedApplications_ShoudlReturnAllApplicationsIsCheckedOn_False()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Application post1 = new Application()
            {
                Id = 1,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            Application post2 = new Application()
            {
                Id = 2,
                UserId = "test2",
                User = user,
                IsChecked = false,
            };

            context.Users.Add(user);
            context.Applications.Add(post1);
            context.Applications.Add(post2);
            context.SaveChanges();

            var result = await service.GetunCkeckedApplicationsAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Applications);
            Assert.Equal(1, result.Applications.Count());
        }

        [Fact]
        public async Task GetAllCkeckedApplications_ShoudlReturnAllApplicationsIsCheckedOn_True()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Application post1 = new Application()
            {
                Id = 1,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            Application post2 = new Application()
            {
                Id = 2,
                UserId = "test",
                User = user,
                IsChecked = false,
            };

            Application post3 = new Application()
            {
                Id = 3,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            context.Users.Add(user);
            context.Applications.Add(post1);
            context.Applications.Add(post2);
            context.Applications.Add(post3);
            context.SaveChanges();

            var result = await service.GetCheckedApplicationsAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Applications);
            Assert.Equal(2, result.Applications.Count());
        }

        [Fact]
        public async Task MoveToJunk_ShouldChangeIscheckedFrom_False_to_True()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Application post1 = new Application()
            {
                Id = 1,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            Application post2 = new Application()
            {
                Id = 2,
                UserId = "test",
                User = user,
                IsChecked = false,
            };

            Application post3 = new Application()
            {
                Id = 3,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            context.Users.Add(user);
            context.Applications.Add(post1);
            context.Applications.Add(post2);
            context.Applications.Add(post3);
            context.SaveChanges();

            Assert.False(post2.IsChecked);

            await service.MoveToJunkAsync(2);

            var result = await service.GetCheckedApplicationsAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result.Applications);
            Assert.Equal(3, result.Applications.Count());
            Assert.True(post2.IsChecked);
        }

        [Fact]
        public async Task MoveToJunk_WithInvalidPostId_ShouldThrowsError()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.MoveToJunkAsync(1));
        }

        [Fact]
        public async Task DeleteApplication_WithInvalidPostId_ShouldThrowsError()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteApplicationAsync(1));
        }

        [Fact]
        public async Task DeleteApplication_ShouldReturnCountOfOnlyTwoApplications()
        {
            User user = new User() { Id = "test", FirstName = "Test", LastName = "Testov" };

            Application post1 = new Application()
            {
                Id = 1,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            Application post2 = new Application()
            {
                Id = 2,
                UserId = "test",
                User = user,
                IsChecked = false,
            };

            Application post3 = new Application()
            {
                Id = 3,
                UserId = "test",
                User = user,
                IsChecked = true,
            };

            context.Users.Add(user);
            context.Applications.Add(post1);
            context.Applications.Add(post2);
            context.Applications.Add(post3);
            context.SaveChanges();

            await service.DeleteApplicationAsync(3);

            var result = await context.Applications.ToListAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }
    }
}
