using DataModels.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [StringLength(ConstantsData.MaxDescriptionLength, MinimumLength = ConstantsData.MinPostLength)]
        public string? Title { get; set; }
        [StringLength(ConstantsData.MaxDescriptionLength, MinimumLength = ConstantsData.MinDescriptionLength)]
        public string? Text { get; set; }
        public string? DatePublishedOn { get; set; }
    }
}
