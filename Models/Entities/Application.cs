using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entities
{
    public class Application
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Description { get; set; }
        public bool IsChecked { get; set; }
    }
}
