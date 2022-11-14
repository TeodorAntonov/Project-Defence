using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize(Roles = "Administrator")]
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
                var model = await _adminMailboxService.GetunCkeckedApplicationsAsync();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> MoveToJunk(int applicationId)
        {
            if (applicationId == null)
            {
                return BadRequest("There is no such a Gym. Go Back.");
            }

            await _adminMailboxService.MoveToJunkAsync(applicationId);

            return RedirectToAction("GetAdminMailbox", "AdminMailbox");
        }

        [HttpGet]
        public async Task<IActionResult> GetJunkMailbox()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var model = await _adminMailboxService.GetCheckedApplicationsAsync();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteMail(int applicationId)
        {
            if (applicationId == null)
            {
                return BadRequest("There is no such a Gym. Go Back.");
            }
            await _adminMailboxService.DeleteApplicationAsync(applicationId);

            return RedirectToAction("GetAdminMailbox", "AdminMailbox");
        }
    }
}
