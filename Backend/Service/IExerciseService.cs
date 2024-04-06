using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Service
{
    public interface IExerciseService
    {
        public AllExercisesResponseModel GetAllExercises(int userId);
        public ExerciseResponseModel AddExerciseToUser(int userId, ExerciseRequestModel exercise);

        public void DeleteExerciseById(int exerciseId);
        public ExerciseResponseModel? UpdateExercise(int exerciseId, ExerciseUpdateRequestModel exercise);
    }
}
