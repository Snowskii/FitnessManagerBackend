using System.ComponentModel.DataAnnotations;

namespace Backend.Models.RequestModels
{
    public class WorkoutUpdateRequestModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> ExerciseIds { get; set; }
    }

}
