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

namespace UnitTests.ControllersTests
{
    public class AdminMailboxControllerTests
    {
        private Mock<IAdminMailboxService> serviceMock;
        public AdminMailboxControllerTests()
        {
            serviceMock = new Mock<IAdminMailboxService>();
        }

        [Fact]
        public async Task GetAdminMailbox_ShouldReturnNegativeResult_RedirectToActionResult()
        {
            var controller = new AdminMailboxController(serviceMock.Object);

            var result = await controller.GetAdminMailbox();

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task GetAdminMailbox_ShouldReturnPositiveResult_ViewResult()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            var controller = new AdminMailboxController(serviceMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.GetAdminMailbox();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }


        [Fact]
        public async Task GetJunkMailbox_ShouldReturn_RedirectToActionResult()
        {
            var controller = new AdminMailboxController(serviceMock.Object);

            var result = await controller.GetJunkMailbox();

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task GetJunkMailbox_ShouldReturnPositiveResult_ViewResult()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            var controller = new AdminMailboxController(serviceMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.GetJunkMailbox();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task MoveToJunk_ShouldReturn_RedirectToActionResult()
        {
            var controller = new AdminMailboxController(serviceMock.Object);

            var result = await controller.MoveToJunk(1);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetAdminMailbox", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteMail_ShouldReturn_RedirectToActionResult()
        {
            var controller = new AdminMailboxController(serviceMock.Object);

            var result = await controller.DeleteMail(1);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetAdminMailbox", redirectToActionResult.ActionName);
        }
    }
}
