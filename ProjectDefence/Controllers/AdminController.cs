﻿using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjectDefence.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminService _adminService;
        public AdminController(UserManager<User> userManager, IAdminService adminService)
        {
            _userManager = userManager;
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddGymToSystem()
        {
            var model = new GymViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGymToSystem(AddGymViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adminService.AddGymAsync(model);
            return RedirectToAction(nameof(AdminPanel));
        }

        [HttpGet]
        public async Task<IActionResult> EditGym(int gymId)
        {
            var model = await _adminService.GetGymById(gymId);

            if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditGym(int gymId, AddGymViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            if (gymId == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            bool isSuccess = await _adminService.EditGymAsync(gymId, model);

            if (isSuccess)
            {
                return RedirectToAction("All", "Gyms");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteGym(int gymId)
        {
            if (gymId == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }
            await _adminService.DeleteGymAsync(gymId);

            return RedirectToAction("All", "Gyms");
        }

        [HttpGet]
        public IActionResult AddTrainerToSystem()
        {
            var model = new TrainerViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainerToSystem(AddTrainerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adminService.AddTrainerAsync(model);
            return RedirectToAction(nameof(AdminPanel));
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainer(int trainerId)
        {
            var model = await _adminService.GetTrainerById(trainerId);

            if (model == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTrainer(int trainerId, AddTrainerViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            if (trainerId == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            bool isSuccess = await _adminService.EditTrainerAsync(trainerId, model);

            if (isSuccess)
            {
                return RedirectToAction("AllTrainers", "Trainers");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            var model = await _adminService.GetUserById(userId);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string userId, EditUserViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            if (userId == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            bool isSuccess = await _adminService.EditUserAsync(userId, model);

            if (isSuccess)
            {
                return RedirectToAction("AdminPanel", "Admin");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            var userIdAdmin = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == userIdAdmin)
            {
                return RedirectToAction("BadRequestAdmin", "Error");
            }

            if (userId == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            await _adminService.DeleteUserAsync(userId);

            return RedirectToAction("AdminPanel", "Admin");
        }

        public async Task<IActionResult> DeleteTrainer(int trainerId)
        {
            if (trainerId == null)
            {
                return BadRequest("There is no such a Gym. Go Back.");
            }
            await _adminService.DeleteTrainerAsync(trainerId);

            return RedirectToAction("AllTrainers", "Trainers");
        }

        [HttpGet]
        public async Task<IActionResult> RoleToUser()
        {
            var model = new RoleToUserViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleToUser(IEnumerable<RoleToUserViewModel> model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model = await _adminService.GetAllUsersAsync();
            return View(model);
        }
    }
}
