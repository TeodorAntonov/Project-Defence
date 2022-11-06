using DataModels.Entities;
using DataModels.Models;

namespace Interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetUserProfile(User user);
        Task UpdateUserProfile(User user, ProfileViewModel model);
    }
}
