using DataModels.Constants;
using DataModels.Models;
using DataModels.Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExerciseService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddExerciseAsync(ExerciseViewModel model)
        {
            var Exercise = new Exercise()
            {
                Description = model.Description,
                Name = model.Name,
                ImageUrl = UploadedFileExercise(model),
            };

            await _context.Exercises.AddAsync(Exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync()
        {
            var exercies = await _context.Exercises.OrderBy(e => e.Name).ToListAsync();

            return exercies.Select(e => new ExerciseViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                ImageUrl = e.ImageUrl != null ? $"/UploadedFiles/{e.ImageUrl}" : $"/UploadedFiles/empty_action_avatar.png",
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
                ImageUrl = exercise.ImageUrl != null ? $"/UploadedFiles/{exercise.ImageUrl}" : $"/UploadedFiles/empty_action_avatar.png",
                Description = exercise.Description ?? null,
            };

        }

        private string UploadedFileExercise(ExerciseViewModel model)
        {
            string fileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedFiles");
                fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
