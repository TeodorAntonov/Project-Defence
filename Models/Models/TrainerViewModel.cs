namespace DataModels.Models
{
    public class TrainerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }
        public string? Experience { get; set; }
        public bool IsAvailable { get; set; }
    }
}
