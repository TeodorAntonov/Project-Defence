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

        public async Task<IActionResult> GetExercise(int exerciseId)
        {
            if (exerciseId == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            var model = await _exerciseService.GetExerciseAsync(exerciseId);

            if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(model);
        }
    }
}
