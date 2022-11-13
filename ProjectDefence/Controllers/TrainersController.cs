using DataModels.Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class TrainersController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly UserManager<User> _userManager;
        public TrainersController(ITrainerService trainerService, UserManager<User> userManager)
        {
            _trainerService = trainerService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AllTrainers()
        {
            var model = await _trainerService.GetAllTrainersAsync();
            return View(model);
        }

        [HttpGet]
        [Authorize("Trainer")]
        public async Task<ActionResult> GetClients(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("There is no such user! Go Back!");
            }
            var model = await _trainerService.GetClientsAsync(user);
            return View(model);
        }

        [HttpGet]
        [Authorize("Trainer")]
        public async Task<ActionResult> GetClientsRequests(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("There is no such user! Go Back!");
            }
            var model = await _trainerService.GetClientsRequestsAsync(user);
            return View(model);
        }
    }
}
