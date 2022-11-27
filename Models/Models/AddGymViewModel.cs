using DataModels.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public IFormFile? ImageUrl { get; set; }
        public bool HasImageUrl { get; set; }
    }
}
