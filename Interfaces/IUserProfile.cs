using DataModels.Models;

namespace Interfaces
{
    public interface IUserProfile
    {
        Task<ProfileViewModel> MyProfile(string id);
    }
}
