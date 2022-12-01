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
    public class ClientControllerTests
    {
        private Mock<IClientService> serviceMock;
        private Mock<UserManager<User>> userServiceMock;
        public ClientControllerTests()
        {
            serviceMock = new Mock<IClientService>();
            userServiceMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        }


        [Fact]
        public async Task ApplyForTrainer_ShouldReturn_RedirectToActionResult_BadRequest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            serviceMock.Setup(x => x.ApplyingForTrainerAsync(It.IsAny<User>(), It.IsAny<int>())).ReturnsAsync(true);

            var controller = new ClientController(serviceMock.Object, userServiceMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.ApplyForTrainer(1);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("BadRequest", redirectToActionResult.ActionName);
        }
    }
}
