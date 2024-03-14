using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{

    public enum ExerciseType
    {
        Time,
        Amount
    }
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public ExerciseType Type { get; set; }

        public int TypeAmount { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int WorkoutId { get; set; }
        public List<Workout> Workouts { get; set; } = [];

        public List<WorkoutExercise> WorkoutExercises { get; set; } = [];
    }
}
