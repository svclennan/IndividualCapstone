using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        private readonly string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MoodTracker;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<MoodTracker> MoodTrackers { get; set; }
        public DbSet<PlaylistRating> PlaylistRatings { get; set; }
    }
}
