using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entities
{
    public record Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string? ImageUrl { get; set; }
        public string? Experience { get; set; }
        public bool IsAvailable { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Client>? Clients { get; set; } = new HashSet<Client>();
        public virtual ICollection<Client>? ClientsApplications { get; set; } = new HashSet<Client>();
        public virtual ICollection<Gym>? Gyms { get; set; } = new HashSet<Gym>();
    }
}
