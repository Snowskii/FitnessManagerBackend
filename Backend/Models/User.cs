
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public enum Role
    {
        Admin,
        User
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public static int CountOfWorkoutsDone { get; set; }
        public List<UserMilestone> UserMilestones { get; set; } = [];
        public List<Milestone> Milestones { get; set; } = [];
        public List<Exercise> Exercises { get; set; } = [];
        public List<Workout> Workouts { get; set; } = [];
    }
}
