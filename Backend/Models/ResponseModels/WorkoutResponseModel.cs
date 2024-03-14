using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ResponseModels
{
    public class WorkoutResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExerciseResponseModel> Exercises { get; set; }
    }
}
