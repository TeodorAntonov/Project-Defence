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
        public User? User { get; set; }
        public virtual ICollection<User> Clients { get; set; } = new HashSet<User>();
        public virtual ICollection<Gym> Gyms { get; set; } = new HashSet<Gym>();
    }
}
