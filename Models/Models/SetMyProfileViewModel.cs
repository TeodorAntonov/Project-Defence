using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class SetMyProfileViewModel
    {
        [Range(1, 150)]
        public int? Age { get; set; }
        [Range(1, 600)]
        public double? Weight { get; set; }
        [Range(1, 600)]
        public double? Height { get; set; }
    }
}
