using DataModels.Models;

namespace Interfaces
{
    public interface IProfileService
    {
        Task GetUserProfile(ProfileViewModel model);
    }
}
