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
using Microsoft.AspNetCore.Hosting;

namespace UnitTests
{
    public class ExerciseServiceTests
    {
        private ExerciseService service;
        private IWebHostEnvironment webHostEnvironment;
        ApplicationDbContext context;
        public ExerciseServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new ExerciseService(context, webHostEnvironment);
        }

        [Fact]
        public async Task GetAllExercises_ShouldReturnAllExercises_PositiveResult()
        {
            Exercise test1 = new Exercise()
            {
                Name = "Test",
            };

            Exercise test2 = new Exercise()
            {
                Name = "Test2",
            };

            context.Exercises.Add(test1);
            context.Exercises.Add(test2);

            context.SaveChanges();

            var result = await service.GetAllExercisesAsync();

            Assert.NotEmpty(result);
            Assert.Equal(result.Count(), 7);
        }

        [Fact]
        public async Task GetAllExercises_OnlyExerciseWithCurtainName_PositiveResult()
        {
            Exercise test1 = new Exercise()
            {
                Name = "Test",
            };

            Exercise test2 = new Exercise()
            {
                Name = "Test2",
            };

            context.Exercises.Add(test1);
            context.Exercises.Add(test2);

            context.SaveChanges();

            var result = await service.GetExerciseAsync(6);
            var result2 = await service.GetExerciseAsync(7);

            Assert.Equal(6, result.Id);
            Assert.Equal(result.Name, "Test");
            Assert.Equal(7, result2.Id);
            Assert.Equal(result2.Name, "Test2");
        }

        [Fact]
        public async Task DeleteExercise_WithInvalidIdThrowsError()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteExerciseAsync(1));
        }

        [Fact]
        public async Task DeleteExercise_ShouldDeleteExerciseAndReturnTheDefaultExerciseListCount_5()
        {
            Exercise exercise = new Exercise()
            {
                Id = 6,
                Name = "Test"
            };

            await context.Exercises.AddAsync(exercise);
            await context.SaveChangesAsync();

            var list = await context.Exercises.ToListAsync();

            Assert.NotEmpty(list);
            Assert.Equal(list.Count(), 6);

            await service.DeleteExerciseAsync(1);

            list = await context.Exercises.ToListAsync();

            Assert.Equal(5, list.Count());
        }


        [Fact]
        public async Task AddPost_ShouldReturnOnePostCout_PositiveResult()
        {
            ExerciseViewModel model = new ExerciseViewModel()
            {
                Name = "Name",
                Description = "Address",
            };

            await service.AddExerciseAsync(model);

            var exercises = await context.Exercises.ToListAsync();

            Assert.NotEmpty(exercises);
            Assert.Equal(exercises.Count(), 6);
            Assert.Equal(exercises.Last().Id, 6);
        }
    }
}
