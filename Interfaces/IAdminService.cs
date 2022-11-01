using DataModels.Models;

namespace Interfaces
{
    public interface IAdminService
    {
        Task AddRolesToUsers(string email);
        Task AddGymAsync(AddGymViewModel model);
        Task AddTrainerAsync(AddTrainerViewModel model);
    }
}
