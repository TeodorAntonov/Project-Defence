using DataModels.Constants;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(ConstantsData.MaxUserNameLenth, MinimumLength = ConstantsData.MinUserNameLenth)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(ConstantsData.MaxPasswordLength, MinimumLength = ConstantsData.MinPasswordLength)]
        public string Password { get; set; }
    }
}
