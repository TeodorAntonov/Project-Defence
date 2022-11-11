using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class AdminMailboxController : Controller
    {
        private readonly IAdminMailboxService _adminMailboxService;
        public AdminMailboxController(IAdminMailboxService adminMailboxService)
        {
            _adminMailboxService = adminMailboxService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminMailbox()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var model = await _adminMailboxService.GetAllApplicationsAsync();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
