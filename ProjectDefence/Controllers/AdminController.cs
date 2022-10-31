using DataModels.Constants;
using DataModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddAdminUser()
        {
            var id = "2ddbef1b-9d8d-4926-9c42-d47f3561021a";
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.ClientRole, ConstantsRoles.TrainerRole });

            return RedirectToAction("Index", "Home");
        }
    }
}
