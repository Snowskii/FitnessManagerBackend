using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Backend.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Exercise> Exercises { get; set; }

        public List<WorkoutExercise> WorkoutsExercises { get; set; }
    }
}
