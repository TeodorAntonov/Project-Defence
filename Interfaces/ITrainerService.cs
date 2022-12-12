using DataModels.Entities;
using DataModels.Models;

namespace Interfaces
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerViewModel>> GetAllTrainersAsync();
        Task<IEnumerable<ClientViewModel>> GetClientsAsync(User user);
        Task<IEnumerable<ClientViewModel>> GetClientsRequestsAsync(User user);
        Task DeleteRequestAsync(User user, int clientId);
        Task DeleteClientAsync(User user, int clientId);
        Task AddClientAsync(User user, int clientId);
        Task<ClientViewModel> CreateWorkoutAsync(User user, int clientId);
        Task SaveWorkoutAsync(User user, int clientId, ClientViewModel model);
        Task ChangeAvailabilityAsync(User user);
    }
}
