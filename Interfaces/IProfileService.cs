using DataModels.Entities;
using DataModels.Models;

namespace Interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetUserProfile(User user);
        Task UpdateUserProfile(User user, UpdateMyProfileViewModel model);
        Task SetUserProfile(User user, SetMyProfileViewModel model);
        IEnumerable<SportViewModel> GetSports();

        Task ClearAllNotes(Client client);
        Task DeleteTrainerWrokout(Client client);
    }
}
