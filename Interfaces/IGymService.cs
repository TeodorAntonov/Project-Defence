using DataModels.Models;

namespace Interfaces
{
    public interface IGymService
    {
        Task<IEnumerable<GymViewModel>> GetAllGymsAsync();
    }
}
