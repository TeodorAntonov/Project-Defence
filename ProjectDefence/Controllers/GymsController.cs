using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class GymsController : Controller
    {
        private readonly IGymService _gymService;
        public GymsController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _gymService.GetAllGymsAsync();
            return View(model);
        }
    }
}
