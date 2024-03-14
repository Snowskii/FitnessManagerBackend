namespace Backend.Models.ResponseModels
{
    public class AllWorkoutsResponseModel
    {
        public IEnumerable<WorkoutResponseModel> Workouts { get; set; }
    }
}
