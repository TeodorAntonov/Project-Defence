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
    public class GymServiceTests
    {
        private GymService service;
        ApplicationDbContext context;

        public GymServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new GymService(context);
        }

        [Fact]
        public async Task GetAllGyms_ShouldReturnAllGyms_PositiveResult()
        {
            Gym gym = new Gym()
            {
                Name = "Name",
                Address = "Address"
            };

            Gym gym2 = new Gym()
            {
                Name = "Name2",
                Address = "Address2"
            };

            context.Gyms.Add(gym);
            context.Gyms.Add(gym2);

            context.SaveChanges();

            var result = await service.GetAllGymsAsync();

            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 5);
        }

        [Fact]
        public async Task GetAllGyms_ShouldReturn_ThreeHardCodedGyms_PositiveResult()
        {
            var result = await service.GetAllGymsAsync();

            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 3);
        }

        [Fact]
        public async Task GetAllGyms_ShouldCheckLastAddedGymNameAndAddress_PositiveResult()
        {
            Gym gym = new Gym()
            {
                Name = "Name",
                Address = "Address"
            };

            Gym gym2 = new Gym()
            {
                Name = "Name2",
                Address = "Address2"
            };

            context.Gyms.Add(gym);
            context.Gyms.Add(gym2);

            context.SaveChanges();

            var result = await service.GetAllGymsAsync();

            Assert.NotEmpty(result);
            Assert.Equal(result.Last().Name, "Name2");
            Assert.Equal(result.Last().Address, "Address2");
        }
    }
}
