using DataModels.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminMailboxService : IAdminMailboxService
    {
        private readonly ApplicationDbContext _context;
        public AdminMailboxService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminMailboxViewModel> GetAllApplicationsAsync()
        {
            var applications = await _context.Applications.Include(a => a.User).ToListAsync();
            var mailbox = new AdminMailboxViewModel();

            mailbox.Applications = applications.Select(a => new ApplicationFormForTrainersViewModel()
            {
                Name = a.Name,
                Email = a.Email,
                Telephone = a.Telephone,
                Description = a.Description,
                UserId = a.UserId,
                Username = $"{a.User.FirstName} {a.User.LastName}",
            });

            return mailbox;    
        }
    }
}
