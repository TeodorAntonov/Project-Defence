using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class UpdateMyProfileViewModel
    {
        [Range(1, 150,  ErrorMessage = "Age for {0} must be between {1} and {2}.")]
        public int? Age { get; set; }
        [Range(1, 500, ErrorMessage = "Weight for {0} must be between {1} and {2}.")]
        public double? Weight { get; set; }
        [Range(1, 300, ErrorMessage = "Height for {0} must be between {1} and {2}.")]
        public double? Height { get; set; }
        public string? Notes { get; set; }
        public string? SetGoals { get; set; }
        public string? Trainer { get; set; }
        public string? WorkoutPlan { get; set; }
        public int TypeOfSportId { get; set; }
        public IEnumerable<SportViewModel>? TypeOfSports { get; set; }
    }
}
