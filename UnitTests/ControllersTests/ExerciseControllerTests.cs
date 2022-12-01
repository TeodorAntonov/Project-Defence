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
    public class ExerciseControllerTests
    {
        private Mock<IExerciseService> serviceMock;
        public ExerciseControllerTests()
        {
            serviceMock = new Mock<IExerciseService>();
        }

        [Fact]
        public async Task AllExercises_ShouldReturn_ViewResult()
        {
            var controller = new ExerciseController(serviceMock.Object);

            var result = await controller.AllExercises();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }


        [Fact]
        public async Task GetExercise_ShouldReturn_RedirectToAction_NotFound()
        {
            serviceMock.Setup(x => x.GetExerciseAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<ExerciseViewModel>);

            var controller = new ExerciseController(serviceMock.Object);

            var result = await controller.GetExercise(1);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("NotFound", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task GetExercise_ShouldReturn_ViewResult()
        {
            serviceMock.Setup(x => x.GetExerciseAsync(It.IsAny<int>())).ReturnsAsync(new ExerciseViewModel() { Id = 1 });

            var controller = new ExerciseController(serviceMock.Object);
            
            var result = await controller.GetExercise(1);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }
    }
}
