using System.ComponentModel.DataAnnotations;

namespace Backend.Models.RequestModels
{
    public class WorkoutUpdateRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<WorkoutExercise> WorkoutsExercises { get; set; }
    }

    public class ExerciseC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int UserId { get; set; }
        public ExerciseType Type { get; set; }
        public int TypeAmount { get; set; }
    }
}
