using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDefence.Data;

namespace ProjectDefence.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleInManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              RoleManager<IdentityRole> roleInManager,
                              ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleInManager = roleInManager;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login");

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var client = new Client()
                {
                    UserId = user.Id,
                };

                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> CreateRoles()
        {
            await _roleInManager.CreateAsync(new IdentityRole(ConstantsRoles.AdminRole));
            await _roleInManager.CreateAsync(new IdentityRole(ConstantsRoles.ClientRole));
            await _roleInManager.CreateAsync(new IdentityRole(ConstantsRoles.TrainerRole));

            return RedirectToAction("Index", "Home");
        }

        //TO SET THE ADMIN USER ROLE FIRST TURN ON THE PROJECT. THEN ADD TO THE URL /User/AddAdminUser AND PRESS ENTER 
        [AllowAnonymous]
        public async Task<IActionResult> AddAdminUser()
        {
            var email = "Administrator";
            var user = await _userManager.FindByNameAsync(email);
            await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.ClientRole, ConstantsRoles.TrainerRole });

            return RedirectToAction("Index", "Home");
        }
    }
}
