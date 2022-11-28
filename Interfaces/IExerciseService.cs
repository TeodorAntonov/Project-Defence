using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync();
        Task<ExerciseViewModel> GetExerciseAsync(int exerciseId);
        Task AddExerciseAsync(ExerciseViewModel model);
    }
}
