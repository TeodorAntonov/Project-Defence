using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationFormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateApplicationAsync(ApplicationFormForTrainersViewModel model, string userId)
        {
            var application = new Application()
            {
                Name = model.Name,
                UserId = userId,
                Email = model.Email,
                Telephone = model.Telephone,
                Description = model.Description,
                IsChecked = false,
            };
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }
    }
}
