using DataModels.Constants;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(ConstantsData.MaxUserNameLenth, MinimumLength = ConstantsData.MinUserNameLenth)]
        public string UserName { get; set; }

        [Required]
        [StringLength(ConstantsData.MaxUserNameLenth, MinimumLength = ConstantsData.MinUserNameLenth)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(ConstantsData.MaxPasswordLength, MinimumLength = ConstantsData.MinPasswordLength)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(ConstantsData.MaxFullNameLenth, MinimumLength = ConstantsData.MinFullNameLenth)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxFullNameLenth, MinimumLength = ConstantsData.MinFullNameLenth)]
        public string LastName { get; set; }
    }
}
