using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProfileService _profileService;

        public ProfileController(UserManager<User> userManager, IProfileService profileService)
        {
            _userManager = userManager;
            _profileService = profileService;
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var model = new ProfileViewModel();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            await _profileService.GetUserProfile(model);
            return View(model);
        }
    }
}
