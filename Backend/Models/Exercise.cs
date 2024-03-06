using System.ComponentModel.DataAnnotations;

namespace backend.Models
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

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
