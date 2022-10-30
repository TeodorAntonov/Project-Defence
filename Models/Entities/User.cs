using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Entities
{
    public class User : IdentityUser
    {
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
    }
}
