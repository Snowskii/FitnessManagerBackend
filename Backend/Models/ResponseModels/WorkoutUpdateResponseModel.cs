namespace Backend.Models.ResponseModels
{
    public class WorkoutUpdateResponseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
