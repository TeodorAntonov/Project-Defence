using DataModels.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Models
{
    public class AddTrainerViewModel
    {
        [Required]
        [StringLength(ConstantsData.MaxTrainerNameLength, MinimumLength = ConstantsData.MinTrainerNameLength)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxTelephoneLength, MinimumLength = ConstantsData.MinTelephoneLength)]
        public string Telephone { get; set; }
        public string? Experience { get; set; }
        [NotMapped]
       // [Required(ErrorMessage = "Please choose image")]
        public IFormFile? ImageUrl { get; set; }
        public string IsAvailable { get; set; } = "Yes";
        public string? UserId { get; set; }

        public bool HasImageUrl { get; set; }
       
    }
}
