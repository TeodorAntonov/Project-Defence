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

        public IActionResult GetAllExercies()
        {
            var model = _exerciseService.GetAllExercies();
            return View(model);
        }
    }
}
