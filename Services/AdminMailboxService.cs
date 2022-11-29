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

        public async Task<AdminMailboxViewModel> GetunCkeckedApplicationsAsync()
        {
            var applications = await _context.Applications.Include(a => a.User).Where(a =>!a.IsChecked).ToListAsync();
            var mailbox = new AdminMailboxViewModel();

            mailbox.Applications = applications.Select(a => new ApplicationFormForTrainersViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Telephone = a.Telephone,
                Description = a.Description,
                UserId = a.UserId,
                Username = $"{a.User.FirstName} {a.User.LastName}",
            });

            return mailbox;
        }

        public async Task<AdminMailboxViewModel> GetCheckedApplicationsAsync()
        {
            var applications = await _context.Applications.Include(a => a.User).Where(a => a.IsChecked).ToListAsync();

            var mailbox = new AdminMailboxViewModel();

            mailbox.Applications = applications.Select(a => new ApplicationFormForTrainersViewModel()
            {
                Id= a.Id,
                Name = a.Name,
                Email = a.Email,
                Telephone = a.Telephone,
                Description = a.Description,
                UserId = a.UserId,
                Username = $"{a.User.FirstName} {a.User.LastName}",
            });

            return mailbox;
        }

        public async Task MoveToJunkAsync(int applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            if (application == null)
            {
                throw new ArgumentException("No such user Id.");
            }
            application.IsChecked = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(int applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);

            if (application != null)
            {
                _context.Applications.Remove(application);
            }

            await _context.SaveChangesAsync();
        }
    }
}
