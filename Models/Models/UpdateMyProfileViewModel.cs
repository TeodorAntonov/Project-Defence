﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class UpdateMyProfileViewModel
    {
        [Range(1, 150)]
        public int? Age { get; set; }
        [Range(1, 500)]
        public double? Weight { get; set; }
        [Range(1, 300)]
        public double? Height { get; set; }
        public string? Notes { get; set; }
        public string? SetGoals { get; set; }
        public string? Trainer { get; set; }
        public string? WorkoutPlan { get; set; }
        public IEnumerable<SportViewModel>? TypeOfSports { get; set; }

    }
}
