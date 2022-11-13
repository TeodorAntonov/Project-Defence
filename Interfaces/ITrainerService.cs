using DataModels.Entities;
using DataModels.Models;

namespace Interfaces
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerViewModel>> GetAllTrainersAsync();
        Task<IEnumerable<ClientViewModel>> GetClientsAsync(User user);
        Task<IEnumerable<ClientViewModel>> GetClientsRequestsAsync(User user);
    }
}
