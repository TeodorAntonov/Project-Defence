using DataModels.Entities;
using DataModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class AdminMailboxController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AdminMailboxController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AdminMailbox()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var model = new AdminMailboxViewModel();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
