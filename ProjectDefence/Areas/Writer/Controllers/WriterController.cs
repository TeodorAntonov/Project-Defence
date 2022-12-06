using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class WriterController : Controller
    {
        private readonly IPostService _postService;
        private readonly IExerciseService _exerciseService;

        public WriterController(IPostService postService, IExerciseService exerciseService)
        {
            _postService = postService;
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult GetWriterScreen()
        {
            var model = new WriterViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            var model = new PostViewModel();
            return View(model);
        }

        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            
            await _postService.AddPostAsync(model);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeletePost(int postId)
        {
            if (postId == null)
            {
                return BadRequest("There is no such a Post. Go Back.");
            }
            await _postService.DeletePostAsync(postId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            var model = new ExerciseViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(ExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _exerciseService.AddExerciseAsync(model);
            return RedirectToAction("AllExercises", "Exercise");
        }

        public async Task<IActionResult> DeleteExercise(int exerciseId)
        {
            if (exerciseId == null)
            {
                return BadRequest("There is no such a Exercise. Go Exercise.");
            }
            await _exerciseService.DeleteExerciseAsync(exerciseId);

            return RedirectToAction("AllExercises", "Exercise");
        }
    }
}
