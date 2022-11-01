using DataModels.Constants;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public class AddGymViewModel
    {
        [Required]
        [StringLength(ConstantsData.MaxGymNameAndAddressLength, MinimumLength = ConstantsData.MinGymNameAndAddressLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxGymNameAndAddressLength, MinimumLength = ConstantsData.MinGymNameAndAddressLength)]
        public string Address { get; set; }
        public string? ImageUrl { get; set; }
    }
}
