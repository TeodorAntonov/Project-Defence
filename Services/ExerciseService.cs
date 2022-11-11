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

        public async Task<IEnumerable<ExerciseViewModel>> GetAllExercies()
        {
            var exercies = await _context.Exercises.OrderBy(e => e.Name).ToListAsync();

            return exercies.Select(e => new ExerciseViewModel() 
            {
                Id = e.Id,
                Name = e.Name,
                ImageUrl = e.ImageUrl ?? null,
               // Description = e.Description
            });
        }
    }
}
