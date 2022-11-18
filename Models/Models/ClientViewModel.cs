using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class CreateExerciseViewModel
    {
        public int WorkoutId { get; set; }
        public string ExerciseName { get; set; }
        public string SetRound { get; set; }
        public string Rep { get; set; }
    }

    public class ClientViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string? TypeOfSport { get; set; }
        public string? WorkoutPlan { get; set; }
        ////public List<CreateExerciseViewModel> WorkoutPlan { get; set; } = new List<CreateExerciseViewModel>();
        //public CreateExerciseViewModel CurrentExercise { get; }
        //public int? CountOfExercises { get; set; }
    }
}
