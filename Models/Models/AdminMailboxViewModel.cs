using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class AdminMailboxViewModel
    {
        public IEnumerable<ApplicationFormForTrainersViewModel> Applications { get; set; } = new List<ApplicationFormForTrainersViewModel>();
    }
}
