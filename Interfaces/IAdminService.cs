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
        Task DeleteUserAsync(string userId);
        Task<AddGymViewModel> GetGymById(int gymId);
        Task<AddTrainerViewModel> GetTrainerById(int trainerId);
        Task<bool> EditGymAsync(int gymId, AddGymViewModel model);
        Task<bool> EditTrainerAsync(int trainerId, AddTrainerViewModel model);
        Task<bool> EditUserAsync(string userId, EditUserViewModel model);
        Task<EditUserViewModel> GetUserById(string userId);
    }
}
