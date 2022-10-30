using DataModels.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectDefence.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<GymViewModel> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkOutExercise> WorkOutExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   

            base.OnModelCreating(builder);
        }
    }
}