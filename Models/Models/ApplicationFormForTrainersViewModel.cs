using DataModels.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ApplicationFormForTrainersViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxTrainerNameLenth, MinimumLength = ConstantsData.MinTrainerNameLenth)]
        public string Name { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxEmailNameLength, MinimumLength = ConstantsData.MinEmailNameLength)]
        public string Email { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxTelephoneLength, MinimumLength = ConstantsData.MinTelephoneLength)]
        public string Telephone { get; set; }
        [Required]
        [StringLength(ConstantsData.MaxDescriptionLength, MinimumLength = ConstantsData.MinDescriptionLength)]
        public string Description { get; set; }
    }
}
