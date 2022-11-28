using DataModels.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        [StringLength(ConstantsData.MaxDescriptionLength, MinimumLength = ConstantsData.MinDescriptionLength)]
        public string? Description { get; set; }

        [StringLength(ConstantsData.MaxDescriptionLength, MinimumLength = ConstantsData.MinPartialDescriptionLength)]
        public string? PartialDescription { get; set; }
    }
}
