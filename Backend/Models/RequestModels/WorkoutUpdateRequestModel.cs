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

}
