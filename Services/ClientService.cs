using DataModels.Entities;
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
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ApplyingForTrainerAsync(User user, int trainerId)
        {
            var trainer = await _context.Trainers.FindAsync(trainerId);
            if (trainer == null)
            {
                throw new Exception("There is no such trainer.");
            }

            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(cl => cl.UserId == user.Id);
            if (client == null)
            {
                throw new Exception("There is no such client.");
            }

            if (trainer.Clients.Contains(client))
            {
                return false;
            }
            if (trainer.ClientsApplications.Contains(client))
            {
                return false;
            }
            trainer.ClientsApplications.Add(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
