using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAdminMailboxService
    {
        Task<AdminMailboxViewModel> GetunCkeckedApplicationsAsync();
        Task<AdminMailboxViewModel> GetCheckedApplicationsAsync();
        Task MoveToJunkAsync(int applicationId);
        Task DeleteApplicationAsync(int applicationId);
    }
}
