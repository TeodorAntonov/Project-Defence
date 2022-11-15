using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int? AgeStarted { get; set; }
        public double? WeightStarted { get; set; }
        public double? HeightStarted { get; set; }
        public string? TypeOfSport { get; set; }
        public string? SetGoals { get; set; }
        [ForeignKey(nameof(Trainer))]
        public int? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        public string? WorkoutPlan { get; set; }
        public int? CurrentAge { get; set; }
        public double? CurrentWeight { get; set; }
        public double? CurrentHeight { get; set; }
        public string? ClientNotes { get; set; }
        public bool IsTrainer { get; set; }
        public bool IsAdministrator { get; set; }
    }
}
