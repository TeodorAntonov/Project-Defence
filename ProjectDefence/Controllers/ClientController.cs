using DataModels.Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectDefence.Controllers
{
    [Authorize("Trainer")]
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
        public async Task<ActionResult> ApplyForTrainer(string userId, int trainerId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("There is no such user! Go Back!");
            }
           // var model = await _clientService.GetClientsAsync(user);
            return View();
        }
    }
}
