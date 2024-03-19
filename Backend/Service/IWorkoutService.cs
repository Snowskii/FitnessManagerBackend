using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Service
{
    public interface IWorkoutService
    {
        public AllWorkoutsResponseModel GetAllWorkouts(int userId);
        public WorkoutResponseModel AddWorkout(int userId, WorkoutRequestModel workout);
        public WorkoutResponseModel? GetWorkoutById(int workoutId);
        public void DeleteWorkoutById(int workoutId);
        public WorkoutResponseModel? UpdateWorkout(int workoutId, WorkoutUpdateRequestModel workout);
    }
}
