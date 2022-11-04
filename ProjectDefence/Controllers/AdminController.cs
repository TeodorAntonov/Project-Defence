using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminService _adminService;
        public AdminController(UserManager<User> userManager, IAdminService adminService)
        {
            _userManager = userManager;
            _adminService = adminService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddAdminUser()
        {
            var id = "2ddbef1b-9d8d-4926-9c42-d47f3561021a";
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.ClientRole, ConstantsRoles.TrainerRole });

            return RedirectToAction("Index", "Home");
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
        public async Task< IActionResult> RoleToUser()
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
