using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> AllExercises()
        {
            var model = await _exerciseService.GetAllExercisesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetExercise(int exerciseId)
        {
            var model = await _exerciseService.GetExerciseAsync(exerciseId);
            return View(model);
        }
    }
}
