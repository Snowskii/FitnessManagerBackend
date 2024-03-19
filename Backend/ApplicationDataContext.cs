using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            builder.Entity<User>()
                .HasMany(user => user.Milestones)
                .WithMany(milestone => milestone.Users)
                .UsingEntity<UserMilestone>();

            builder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithMany(e => e.Workouts)
                .UsingEntity<WorkoutExercise>();
        }
    }
}
