using System.ComponentModel.DataAnnotations;

namespace Backend.Models.RequestModels
{
    public class WorkoutUpdateRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<WorkoutExercise> WorkoutsExercises { get; set; }
    }

}
