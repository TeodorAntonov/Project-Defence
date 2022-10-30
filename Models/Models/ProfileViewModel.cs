using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeStarted { get; set; }
        public double WeightStarted { get; set; }
        public double HeightStarted { get; set; }
        public string? TypeOfSport { get; set; }
        public string? SetGoals { get; set; }
        public string? Trainer { get; set; }
        public string? WorkoutPlan { get; set; }
        public int? CurrentAge { get; set; }
        public double? CurrentWeight { get; set; }
        public double? CurrentHeight { get; set; }
        public string? ClientNotes { get; set; }
    }
}
