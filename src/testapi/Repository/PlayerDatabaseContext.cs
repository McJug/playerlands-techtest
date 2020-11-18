using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;

namespace Repository
{
    public class PlayerDatabaseContext : DbContext
    {
        public PlayerDatabaseContext(DbContextOptions<PlayerDatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateIndexes(modelBuilder);

            SeedTestData(modelBuilder);
        }

        private void CreateIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Username)
                .IsUnique();
        }

        private void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasData(new Player
                {
                    Id = 1,
                    Username = "player",
                    Joined = new DateTime(2020, 9, 19),
                    Email = "playerone@gmail.co.uk"
                });

            modelBuilder.Entity<Player>()
                .HasData(new Player
                {
                    Id = 2,
                    Username = "threepigs",
                    Joined = new DateTime(2020, 9, 20),
                    Email = "threepigs@gmail.co.uk"
                });

            modelBuilder.Entity<Player>()
                .HasData(new Player
                {
                    Id = 3,
                    Username = "marioscat",
                    Joined = new DateTime(2020, 8, 30),
                    Email = "johnsmith@hotmail.co.uk"
                });
        }

        public DbSet<Player> Players { get; set; }
    }
}
