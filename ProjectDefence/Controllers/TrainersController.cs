using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> GetClients()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var model = await _trainerService.GetClientsAsync(user);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> GetClientsRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var model = await _trainerService.GetClientsRequestsAsync(user);
            return View(model);
        }

        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> DeleteRequest(int clientId)
        {
            if (clientId == null)
            {
                return RedirectToAction("GetClientsRequests", "Trainers");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            await _trainerService.DeleteRequestAsync(user, clientId);
            return RedirectToAction("GetClientsRequests", "Trainers");
        }

        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> AddClient(int clientId)
        {
            if (clientId == null)
            {
                return RedirectToAction("GetClientsRequests", "Trainers");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            await _trainerService.AddClientAsync(user, clientId);

            return RedirectToAction("GetClientsRequests", "Trainers");
        }

        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> DeleteClient(int clientId)
        {
            if (clientId == null)
            {
                return RedirectToAction("GetClientsRequests", "Trainers");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            await _trainerService.DeleteClientAsync(user, clientId);

            return RedirectToAction("GetClients", "Trainers");
        }


        [HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> CreateWorkout(int clientId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var model = await _trainerService.CreateWorkoutAsync(user, clientId);
            return View(model);
        }

        //[HttpGet]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult> SaveWorkout(int clientId, ClientViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            await _trainerService.SaveWorkoutAsync(clientId, model);
            return RedirectToAction("GetClients", "Trainers");
        }
    }
}
