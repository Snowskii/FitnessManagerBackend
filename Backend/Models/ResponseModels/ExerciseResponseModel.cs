using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ResponseModels
{
    public class ExerciseResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public ExerciseType Type { get; set; }
        public int TypeAmount { get; set; }
    }
}
