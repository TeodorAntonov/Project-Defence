using DataModels.Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ProjectDefence.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService, UserManager<User> userManager)
        {
            _clientService = clientService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> ApplyForTrainer(int trainerId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("There is no such user! Go Back!");
            }
            var result = await _clientService.ApplyingForTrainerAsync(user, trainerId);

            if (!result)
            {
                return RedirectToAction("AlreadyApplied", "Client");
            }

            return RedirectToAction("AllTrainers", "Trainers");
        }

        [HttpGet]
        public async Task<ActionResult> AlreadyApplied()
        {
            return View();
        }
    }
}
