using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public class EditUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Range(1, 150)]
        public int? AgeStarted { get; set; }
        [Range(1, 150)]
        public int? CurrentAge { get; set; }
        [Range(1, 500)]
        public double? WeightStarted { get; set; }
        [Range(1, 500)]
        public double? WeightCurrent { get; set; }
        [Range(1, 300)]
        public double? HeightStarted { get; set; }
        [Range(1, 300)]
        public double? HeightCurrent { get; set; }
        public string? Notes { get; set; }
        public string? SetGoals { get; set; }
        public string? Trainer { get; set; }
        public string? WorkoutPlan { get; set; }
        public string? TypeOfSport { get; set; }
        public bool IsTrainer { get; set; }
        public bool IsAdministrator { get; set; }
        public IEnumerable<SportViewModel>? TypeOfSports { get; set; }
    }
}
