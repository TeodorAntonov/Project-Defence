using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjectDefence.Controllers
{
    [Authorize(Roles = "Client")]
    public class TrainerApplicationController : Controller
    {
        private readonly IApplicationFormService _applicationForm;
        private readonly UserManager<User> _userManager;

        public TrainerApplicationController(IApplicationFormService applicationForm, UserManager<User> userManager)
        {
            _applicationForm = applicationForm;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ApplicationFormForTrainers()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var model = new ApplicationFormForTrainersViewModel();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ApplicationFormForTrainers(ApplicationFormForTrainersViewModel model)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _applicationForm.CreateApplicationAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CancelForm()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
