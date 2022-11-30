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

namespace UnitTests.ControllersTests
{
    public class AdminControllerTests
    {
        private Mock<IAdminService> serviceMock;
        private UserManager<User> userServiceMock;

        public AdminControllerTests()
        {
            serviceMock = new Mock<IAdminService>();
        }

        [Fact]
        public async Task AddGymToSystem_ShouldReturn_RedirectToActionResult()
        {
            var model = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };
            serviceMock.Setup(x => x.AddGymAsync(It.IsAny<AddGymViewModel>())).Returns(Task.FromResult(true));

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.AddGymToSystem(model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task EditGymToSystem_ShouldReturn_RedirectToAction()
        {
            var model = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };
            serviceMock.Setup(x => x.EditGymAsync(It.IsAny<int>(), It.IsAny<AddGymViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditGym(1, model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task EditGymToSystem_ServiceReturnFalse_Should_RedirectToView()
        {
            var model = new AddGymViewModel()
            {
                Name = "Test",
                Address = "Test"
            };
            serviceMock.Setup(x => x.EditGymAsync(It.IsAny<int>(), It.IsAny<AddGymViewModel>())).ReturnsAsync(false);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditGym(1, model);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task EditGymToSystem_WithInvalidModel_RedirectToBadRequestView()
        {
            serviceMock.Setup(x => x.EditGymAsync(It.IsAny<int>(), It.IsAny<AddGymViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditGym(1, null);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("BadRequest", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteGym_ShouldReturn_ActionName_All()
        {
            serviceMock.Setup(x => x.DeleteGymAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.DeleteGym(1);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("All", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task AddTrainerToSystem_ShouldReturn_RedirectToActionResult()
        {
            var model = new AddTrainerViewModel()
            {
                Name = "Test",
                Telephone = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.AddTrainerAsync(It.IsAny<AddTrainerViewModel>())).Returns(Task.FromResult(true));

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.AddTrainerToSystem(model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }
        [Fact]
        public async Task EditTrainerToSystem_ShouldReturn_RedirectToAction()
        {
            var model = new AddTrainerViewModel()
            {
                Name = "Test",
                Telephone = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.EditTrainerAsync(It.IsAny<int>(), It.IsAny<AddTrainerViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditTrainer(1, model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task EditTrainerToSystem_ServiceReturnFalse_Should_RedirectToView()
        {
            var model = new AddTrainerViewModel()
            {
                Name = "Test",
                Telephone = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.EditTrainerAsync(It.IsAny<int>(), It.IsAny<AddTrainerViewModel>())).ReturnsAsync(false);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditTrainer(1, model);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task EditTrainerToSystem_WithInvalidModel_RedirectToBadRequestView()
        {
            serviceMock.Setup(x => x.EditTrainerAsync(It.IsAny<int>(), It.IsAny<AddTrainerViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditTrainer(1, null);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("BadRequest", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteTrainer_ShouldReturn_ActionName_All()
        {
            serviceMock.Setup(x => x.DeleteTrainerAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.DeleteTrainer(1);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("AllTrainers", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task EditUser_ShouldReturn_RedirectToAction_AdminPanel()
        {
            var model = new EditUserViewModel()
            {
                Name = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.EditUserAsync(It.IsAny<string>(), It.IsAny<EditUserViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditUser("test", model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task EditUser_ShouldReturn_ViewResult()
        {
            var model = new EditUserViewModel()
            {
                Name = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.EditUserAsync(It.IsAny<string>(), It.IsAny<EditUserViewModel>())).ReturnsAsync(false);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditUser("test", model);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task EditUser_WithInvalidModel_RedirectToBadRequestView()
        {
            serviceMock.Setup(x => x.EditUserAsync(It.IsAny<string>(), It.IsAny<EditUserViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditUser("test", null);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("BadRequest", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task EditUser_WithInvalidUserId_RedirectToNotFound()
        {
            var model = new EditUserViewModel()
            {
                Name = "Test",
                Email = "Test"
            };
            serviceMock.Setup(x => x.EditUserAsync(It.IsAny<string>(), It.IsAny<EditUserViewModel>())).ReturnsAsync(true);

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.EditUser(null, model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("NotFound", redirectToActionResult.ActionName);
        }


        [Fact]
        public async Task RoleToUser_ShouldReturn_ViewResult()
        {
            RoleToUserViewModel model1 = new RoleToUserViewModel()
            {
                Id = "test1",
                FullName = "Test",
                UserName = "Test",
                Email = "Test",
                Roles = new List<string>()
            };

            var model2 = new RoleToUserViewModel()
            {
                Id = "test2",
                FullName = "Test",
                UserName = "Test",
                Email = "Test",
                Roles = new List<string>()
            };

            var list = new List<RoleToUserViewModel>();
            list.Add(model1); 
            list.Add(model2); 

            var controller = new AdminController(userServiceMock, serviceMock.Object);

            var result = await controller.RoleToUser(list);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }
    }
}
