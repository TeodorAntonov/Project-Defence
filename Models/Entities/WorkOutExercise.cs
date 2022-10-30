using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entities
{
    public record WorkOutExercise
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int? Weight { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int? Rounds { get; set; }
    }
}
