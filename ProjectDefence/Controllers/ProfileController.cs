using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDefence.Data;
using System.Security.Claims;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProfileService _profileService;
        private readonly ApplicationDbContext _context;

        public ProfileController(UserManager<User> userManager, IProfileService profileService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _profileService = profileService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
                var model = await _profileService.GetUserProfile(user);

                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMyProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            var client = _context.Clients.FirstOrDefault(c => c.UserId == user.Id);
            if (client == null)
            {
                return RedirectToAction("BadRequest", "Error");
            }

            UpdateMyProfileViewModel model = new UpdateMyProfileViewModel()
            {
                Age = client.CurrentAge,
                Weight = client.CurrentWeight,
                Height = client.CurrentHeight,
                SetGoals = client.SetGoals,
                //Trainer = client.Trainer,
                TypeOfSports = _profileService.GetSports(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMyProfile(UpdateMyProfileViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            await _profileService.UpdateUserProfile(user, model);

            return RedirectToAction("MyProfile", "Profile");
        }


        [HttpGet]
        public async Task<IActionResult> SetMyProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var client = _context.Clients.FirstOrDefault(c => c.UserId == user.Id);
            if (client == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            SetMyProfileViewModel model = new SetMyProfileViewModel()
            {
                Age = client.AgeStarted,
                Weight = client.WeightStarted,
                Height = client.HeightStarted,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetMyProfile(SetMyProfileViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            await _profileService.SetUserProfile(user, model);

            return RedirectToAction("MyProfile", "Profile");
        }

        public async Task<ActionResult> ClearYourNotes(string confirm_value)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var client = _context.Clients.FirstOrDefault(c => c.UserId == user.Id);
            if (client == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            await _profileService.ClearAllNotes(client);

            return RedirectToAction("MyProfile", "Profile");
        }

        public async Task<ActionResult> DeleteTrainerAndWorkout(string confirm_value)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var client = _context.Clients.FirstOrDefault(c => c.UserId == user.Id);
            if (client == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            await _profileService.DeleteTrainerWrokout(client);

            return RedirectToAction("MyProfile", "Profile");
        }
    }
}
