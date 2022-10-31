using DataModels.Constants;
using DataModels.Entities;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        public AdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task AddRolesToUsers(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            await _userManager.AddToRolesAsync(user, new string[] { ConstantsRoles.AdminRole, ConstantsRoles.ClientRole, ConstantsRoles.TrainerRole });
        }
    }
}
