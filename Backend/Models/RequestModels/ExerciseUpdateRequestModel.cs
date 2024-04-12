namespace Backend.Models.RequestModels
{
    public class ExerciseUpdateRequestModel
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public ExerciseType Type { get; set; }
        public int TypeAmount { get; set; }
    }
}
