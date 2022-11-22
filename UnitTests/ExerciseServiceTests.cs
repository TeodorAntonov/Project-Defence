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

namespace UnitTests
{
    public class ExerciseServiceTests
    {
        private ExerciseService service;
        ApplicationDbContext context;
        public ExerciseServiceTests()
        {
            context = TestDataBaseContext.GetDatabase();
            service = new ExerciseService(context);
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
    }
}
