using DataModels.Entities;
using DataModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectDefence.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private User AdminUser { get; set; }
        private Trainer Trainer1 { get; set; }
        private Trainer Trainer2 { get; set; }
        private Trainer Trainer3 { get; set; }
        private Gym Gym1 { get; set; }
        private Gym Gym2 { get; set; }
        private Gym Gym3 { get; set; }
        private Exercise Exercise1 { get; set; }
        private Exercise Exercise2 { get; set; }
        private Exercise Exercise3 { get; set; }
        private Exercise Exercise4 { get; set; }
        private Exercise Exercise5 { get; set; }
        private Client Client1 { get; set; }
        private Sport Sport1 { get; set; }
        private Sport Sport2 { get; set; }
        private Sport Sport3 { get; set; }
        private Sport Sport4 { get; set; }
        private Sport Sport5 { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkOutExercise> WorkOutExercises { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedAdmin();
            builder.Entity<User>().HasData(AdminUser);

            SeedClient(AdminUser);
            builder.Entity<Client>().HasData(Client1);

            SeedTrainers();
            builder.Entity<Trainer>().HasData(Trainer1, Trainer2, Trainer3);

            SeedGyms();
            builder.Entity<Gym>().HasData(Gym1, Gym2, Gym3);

            SeedExercises();
            builder.Entity<Exercise>().HasData(Exercise1, Exercise2, Exercise3, Exercise4, Exercise5);

            SeedSports();
            builder.Entity<Sport>().HasData(Sport1, Sport2, Sport3, Sport4, Sport5);

            base.OnModelCreating(builder);
        }

        private void SeedAdmin()
        {
            var hasher = new PasswordHasher<User>();

            AdminUser = new User()
            {
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Admin",
                LastName = "User"
            };
            
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin1!");
        }

        private void SeedTrainers()
        {
            this.Trainer1 = new Trainer()
            {
                Id = 1,
                Name = "Ronnie Colman",
                Email = "ronnie@test.com",
                Telephone = "0888777666",
                Experience = "+20 years",
                IsAvailable = true,
            };

            this.Trainer2 = new Trainer()
            {
                Id = 2,
                Name = "Bruce Lee",
                Email = "lee.bruce@test.com",
                Telephone = "0809777111",
                Experience = "15 years",
                IsAvailable = true,
            };
            this.Trainer3 = new Trainer()
            {
                Id = 3,
                Name = "Rocky Balboa",
                Email = "rockybalboa@test.com",
                Telephone = "0899555222",
                Experience = "10 years",
                IsAvailable = true,
            };
        }

        private void SeedGyms()
        {
            this.Gym1 = new Gym()
            {
                Id = 1,
                Name = "Iron Fitness",
                Address = "Bulgaria, Sofia, Mladost"
            };

            this.Gym2 = new Gym()
            {
                Id = 2,
                Name = "Gold Gym",
                Address = "Bulgaria, Sofia, Druzba"
            };
            this.Gym3 = new Gym()
            {
                Id = 3,
                Name = "MMA Arena",
                Address = "Bulgaria, Sofia, Obelya"
            };
        }

        private void SeedExercises()
        {
            Exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Bench Press",

            };

            Exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Deadlift"
            };

            Exercise3 = new Exercise()
            {
                Id = 3,
                Name = "Squat"
            };

            Exercise4 = new Exercise()
            {
                Id = 4,
                Name = "Boxing"
            };

            Exercise5 = new Exercise()
            {
                Id = 5,
                Name = "Pull ups"
            };
        }

        private void SeedSports()
        {
            Sport1 = new Sport()
            {
                Id = 1,
                Name = "Fitness",

            };

            Sport2 = new Sport()
            {
                Id = 2,
                Name = "Crossfit"
            };

            Sport3 = new Sport()
            {
                Id = 3,
                Name = "Climbing"
            };

            Sport4 = new Sport()
            {
                Id = 4,
                Name = "Box"
            };

            Sport5 = new Sport()
            {
                Id = 5,
                Name = "Swiming"
            };
        }

        private void SeedClient(User user)
        {
            Client1 = new Client()
            {
                Id = 1,
                UserId = user.Id,
            };
        }
    }
}