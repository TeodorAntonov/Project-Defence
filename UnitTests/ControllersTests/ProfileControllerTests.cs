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
using ProjectDefence.Data;
using System.Threading;

namespace UnitTests.ControllersTests
{
    public class ProfileControllerTests
    {
        private Mock<IProfileService> serviceMock;
        private ApplicationDbContext context;
        private Mock<UserManager<User>> userServiceMock;
        public ProfileControllerTests()
        {
            serviceMock = new Mock<IProfileService>();
            context = TestDataBaseContext.GetDatabase();
            userServiceMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        }

        [Fact]
        public async Task MyProfile_ShouldReturn_ViewResult()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));


            serviceMock.Setup(x => x.GetUserProfile(It.IsAny<User>())).ReturnsAsync(new ProfileViewModel());

            var controller = new ProfileController(userServiceMock.Object, serviceMock.Object, context);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.MyProfile();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task MyProfile_ShouldReturn_RedirectToIndex()
        {
            var controller = new ProfileController(userServiceMock.Object, serviceMock.Object, context);

            var result = await controller.MyProfile();

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task UpdateMyProfile_ShouldReturn_NotFound()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
             {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
             }, "mock"));

            serviceMock.Setup(x => x.UpdateUserProfile(It.IsAny<User>(), It.IsAny<UpdateMyProfileViewModel>())).Returns(Task.FromResult(true));
            var controller = new ProfileController(userServiceMock.Object, serviceMock.Object, context);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel()
            {
                Age = 1,
                Weight = 1,
                Height = 1,
                SetGoals = "",
                TypeOfSports = null,
            };

            var result = await controller.UpdateMyProfile(model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task SetMyProfile_ShouldReturn_NotFound()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
             {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
             }, "mock"));

            serviceMock.Setup(x => x.SetUserProfile(It.IsAny<User>(), It.IsAny<SetMyProfileViewModel>())).Returns(Task.FromResult(true));
            var controller = new ProfileController(userServiceMock.Object, serviceMock.Object, context);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            SetMyProfileViewModel model = new SetMyProfileViewModel()
            {
                Age = null,
                Weight = null,
                Height = null,
            };

            var result = await controller.SetMyProfile(model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task ClearYourNotes_ShouldReturn_NotFound()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
             {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
             }, "mock"));

            serviceMock.Setup(x => x.ClearAllNotes(It.IsAny<Client>())).Returns(Task.FromResult(true));
            var controller = new ProfileController(userServiceMock.Object, serviceMock.Object, context);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.ClearYourNotes("test");

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }
    }
}
