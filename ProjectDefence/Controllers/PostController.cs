using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> GetFullPost(int postId)
        {
            var model = await _postService.GetFullPostAsync(postId);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllArticles()
        {
            var model = await _postService.GetAllPosts();
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(model);
        }
    }
}
