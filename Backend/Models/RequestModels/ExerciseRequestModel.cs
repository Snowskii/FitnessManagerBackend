using System.ComponentModel.DataAnnotations;

namespace Backend.Models.RequestModels
{
    public class ExerciseRequestModel
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public ExerciseType Type { get; set; }
        public int TypeAmount { get; set; }
    }
}
