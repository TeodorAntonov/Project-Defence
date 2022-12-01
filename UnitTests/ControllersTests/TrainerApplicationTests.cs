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
    public class TrainerApplicationTests
    {
        private Mock<IApplicationFormService> serviceMock;
        public TrainerApplicationTests()
        {
            serviceMock = new Mock<IApplicationFormService>();
        }

        [Fact]
        public async Task ApplicationFormForTrainers_ShouldReturn_RedirectToActionResult_Index()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            var model = new ApplicationFormForTrainersViewModel()
            {
                Id = 1,
                UserId = "test",
                Username = "test",
                Name = "test",
                Email = "test",
                Telephone = "test",
                Description = "test",
            };
            var controller = new TrainerApplicationController(serviceMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = await controller.ApplicationFormForTrainers(model);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task ApplicationFormForTrainersGETMethodModel_ShouldReturn_ViewResult()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "test"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            var controller = new TrainerApplicationController(serviceMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.ApplicationFormForTrainers();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task ApplicationFormForTrainersNegativeResult_ShouldReturn_RedirectToAction()
        {
            var controller = new TrainerApplicationController(serviceMock.Object);
            var result = controller.ApplicationFormForTrainers();

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
        }

        [Fact]
        public async Task ApplicationFormForTrainersCancelFrom_ShouldReturn_RedirectToAction()
        {
            var controller = new TrainerApplicationController(serviceMock.Object);
            var result = controller.CancelForm();

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
