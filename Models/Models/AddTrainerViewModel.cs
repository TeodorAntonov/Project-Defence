using DataModels.Constants;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(ConstantsData.MaxTelephoneLength, MinimumLength = ConstantsData.MaxTelephoneLength)]
        public string Telephone { get; set; }
        public string? Experience { get; set; }
        public string? ImageUrl { get; set; }
        public string IsAvailable { get; set; } = "Yes";
    }
}
