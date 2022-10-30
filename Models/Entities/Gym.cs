namespace DataModels.Entities
{
    public record Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
