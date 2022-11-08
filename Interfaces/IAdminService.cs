using DataModels.Entities;
using DataModels.Models;

namespace Interfaces
{
    public interface IAdminService
    {
        Task AddRolesToUsers(string email);
        Task AddGymAsync(AddGymViewModel model);
        Task AddTrainerAsync(AddTrainerViewModel model);
        Task<IEnumerable<RoleToUserViewModel>> GetAllUsersAsync();
        Task DeleteGymAsync(int gymId);
        Task DeleteTrainerAsync(int trainerId);
        Task<AddGymViewModel> GetGymById(int gymId);
        Task<AddTrainerViewModel> GetTrainerById(int trainerId);
        Task<bool> EditGymAsync(int trainerId, AddGymViewModel model);
        Task<bool> EditTrainerAsync(int trainerId, AddTrainerViewModel model);

    }
}
