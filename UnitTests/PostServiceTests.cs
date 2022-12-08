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
using ProjectDefence.Data;
using DataModels.Entities;

namespace UnitTests
{
    public class PostServiceTests
    {
        private PostService service;
        ApplicationDbContext context;
        public PostServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new PostService(context);
        }

        [Fact]
        public async Task AddPost_ShouldReturnOnePostCout_PositiveResult()
        {
            PostViewModel model = new PostViewModel()
            {
                Title = "Name",
                Text = "Address",
            };

            await service.AddPostAsync(model);

            var posts = await context.Posts.ToListAsync();

            Assert.NotEmpty(posts);
            Assert.Equal(posts.Count(), 1);
        }

        [Fact]
        public async Task GetAllPosts_ShouldReturnPositivePostsCountNumber()
        {
            PostViewModel model = new PostViewModel()
            {
                Title = "NameTest1",
                Text = "AddressTest1",
            };

            PostViewModel model2 = new PostViewModel()
            {
                Title = "NameTest2",
                Text = "AddressTest2",
            };

            PostViewModel model3 = new PostViewModel()
            {
                Title = "NameTest3",
                Text = "AddressTest3",
            };

            await service.AddPostAsync(model);
            await service.AddPostAsync(model2);
            await service.AddPostAsync(model3);

            var posts = await context.Posts.ToListAsync();
            var result = await service.GetAllPosts();

            Assert.NotEmpty(posts);
            Assert.Equal(result.Count(), 3);
        }

        [Fact]
        public async Task GetAllPosts_thorwsError_About_ThePostTitle_not_enough_chars()
        {
            PostViewModel model = new PostViewModel()
            {
                Title = "Name",
                Text = "Address",
            };

            PostViewModel model2 = new PostViewModel()
            {
                Title = "Name",
                Text = "Address",
            };

            PostViewModel model3 = new PostViewModel()
            {
                Title = "Name",
                Text = "Address",
            };

            await service.AddPostAsync(model);
            await service.AddPostAsync(model2);
            await service.AddPostAsync(model3);

            var posts = await context.Posts.ToListAsync();
            var result = await service.GetAllPosts();

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.DeletePostAsync(1));
        }

        [Fact]
        public async Task GetAllPosts_thorwsError_About_ThePostText_not_enough_chars()
        {
            PostViewModel model = new PostViewModel()
            {
                Title = "NameTest1",
                Text = "Address",
            };

            PostViewModel model2 = new PostViewModel()
            {
                Title = "NameTest2",
                Text = "Address",
            };

            PostViewModel model3 = new PostViewModel()
            {
                Title = "NameTest3",
                Text = "Address",
            };

            await service.AddPostAsync(model);
            await service.AddPostAsync(model2);
            await service.AddPostAsync(model3);

            var posts = await context.Posts.ToListAsync();
            var result = await service.GetAllPosts();

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.DeletePostAsync(1));
        }

        [Fact]
        public async Task GetFullPost_AddPostWithService_ShouldReturnPostModelWithCurtainId()
        {

            PostViewModel model = new PostViewModel()
            {
                Title = "Name",
                Text = "Address",
            };

            await service.AddPostAsync(model);
            var result = await service.GetFullPostAsync(1);

            Assert.NotNull(result);
            Assert.Equal(result.GetType(), typeof(PostViewModel));
        }

        [Fact]
        public async Task GetFullPost_ShouldReturnPostWithCurtainId()
        {
            Post post = new Post()
            {
                Id = 1,
                DatePublishedOn = DateTime.Now,
                Title = "Test",
                Text = "Test",
            };

            context.Posts.Add(post);
            context.SaveChanges();

            var result = await service.GetFullPostAsync(1);

            Assert.NotNull(result);
            Assert.Equal(result.GetType(), typeof(PostViewModel));
            Assert.Equal(result.Id, 1);
        }

        [Fact]
        public async Task GetFullPost_ShouldReturnPosDateInDDMMYYYYFormat()
        {
            Post post = new Post()
            {
                Id = 1,
                DatePublishedOn = DateTime.Now,
                Title = "Test",
                Text = "Test",
            };

            context.Posts.Add(post);
            context.SaveChanges();

            var result = await service.GetFullPostAsync(1);

            Assert.Equal(result.DatePublishedOn, DateTime.Now.ToString("dd/MM/yyyy"));
        }


        [Fact]
        public async Task GetLastFourPosts_ShouldReturnLastFourPosts()
        {
            Post post1 = new Post()
            {
                Id = 1,
                DatePublishedOn = DateTime.Now,
                Title = "TestTitleOne",
                Text = "TestTextOne",
            };

            Post post2 = new Post()
            {
                Id = 2,
                DatePublishedOn = DateTime.Now,
                Title = "TestTitleTwo",
                Text = "TestTextTwo",
            };

            Post post3 = new Post()
            {
                Id = 3,
                DatePublishedOn = DateTime.Now,
                Title = "TestTitleThree",
                Text = "TestTextThree",
            };

            Post post4 = new Post()
            {
                Id = 4,
                DatePublishedOn = DateTime.Now,
                Title = "TestTitleFour",
                Text = "TestTextFour",
            };

            Post post5 = new Post()
            {
                Id = 5,
                DatePublishedOn = DateTime.Now,
                Title = "TestTitleFive",
                Text = "TestTextFive",
            };

            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.Posts.Add(post3);
            context.Posts.Add(post4);
            context.Posts.Add(post5);

            context.SaveChanges();

            var result = await service.GetLastFourPosts();

            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 4);
            Assert.Equal(result.First().Id, 5);
            Assert.Equal(result.Last().Id, 2);
        }

        [Fact]
        public async Task DeletePost_ShouldDeletePostAndCollectionShouldBeEmpty()
        {
            Post post1 = new Post()
            {
                Id = 1,
                Title = "test",
                Text = "test"
            };


            await context.Posts.AddAsync(post1);
            await context.SaveChangesAsync();

            var list = await context.Posts.ToListAsync();

            Assert.NotEmpty(list);
            Assert.Equal(list.Count(), 1);

            await service.DeletePostAsync(1);

            list = await context.Posts.ToListAsync();

            Assert.Empty(list);
            Assert.Equal(0, list.Count());
        }

        [Fact]
        public async Task DeletePost_WithInvalidPostIdThrowsError()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeletePostAsync(1));
        }
    }
}
