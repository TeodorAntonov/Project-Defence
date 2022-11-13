using DataModels.Constants;
using DataModels.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync()
        {
            var exercies = await _context.Exercises.OrderBy(e => e.Name).ToListAsync();

            return exercies.Select(e => new ExerciseViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                ImageUrl = e.ImageUrl ?? null,
                Description = e.Description ?? null,
                PartialDescription = e.Description != null ? $"{e.Description.Substring(0, ConstantsData.MinPartialDescriptionLength)}..." : null
            }).ToList();
        }

        public async Task<ExerciseViewModel> GetExerciseAsync(int exerciseId)
        {
            var exercise = await _context.Exercises.FindAsync(exerciseId);

            return new ExerciseViewModel()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                ImageUrl = exercise.ImageUrl ?? null,
                Description = exercise.Description ?? null,
            };

        }
    }
}
