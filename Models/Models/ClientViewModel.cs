using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int? Age { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string? TypeOfSport { get; set; }
        public string? WorkoutPlan { get; set; }
    }
}
