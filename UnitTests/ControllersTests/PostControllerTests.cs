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
    public class PostControllerTests
    {
        private Mock<IPostService> serviceMock;

        public PostControllerTests()
        {
            serviceMock = new Mock<IPostService>();
        }

        [Fact]
        public async Task GetFullPost_ShouldReturn_ViewResult()
        {
            serviceMock.Setup(x => x.GetFullPostAsync(It.IsAny<int>())).ReturnsAsync(new PostViewModel() { Id = 1 });
            var controller = new PostController(serviceMock.Object);

            var result = await controller.GetFullPost(1);

            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public async Task GetFullPost_WithInvalidData_ShouldReturn_RedirectToAction_NotFound()
        {
            serviceMock.Setup(x => x.GetFullPostAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<PostViewModel>);
            var controller = new PostController(serviceMock.Object);

            var result = await controller.GetFullPost(2);

            Assert.Equal(typeof(RedirectToActionResult), result.GetType());
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("NotFound", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task GetAllArticles_ShouldReturn_ViewResult()
        {
            var controller = new PostController(serviceMock.Object);

            var result = await controller.GetAllArticles();

            Assert.Equal(typeof(ViewResult), result.GetType());
        }
    }
}
