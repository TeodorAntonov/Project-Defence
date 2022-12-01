using DataModels.Entities;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DataModels.Models;
using System;
using Microsoft.AspNetCore.Identity;
using ProjectDefence.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace UnitTests.ControllersTests
{
    public class GymControllerTests
    {
        private Mock<IGymService> serviceMock;
        public GymControllerTests()
        {
            serviceMock = new Mock<IGymService>();
        }

        [Fact]
        public async Task AllGyms_ShouldReturn_ViewResult()
        {
            var controller = new GymsController(serviceMock.Object);

            var result = await controller.All();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }
    }
}
