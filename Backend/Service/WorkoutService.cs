using AutoMapper;
using Backend.Infrastructure;
using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Service
{
    public class WorkoutService : IWorkoutService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public WorkoutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WorkoutResponseModel AddWorkout(int userId, WorkoutRequestModel workout)
        {
            var newWorkout = _mapper.Map<WorkoutResponseModel>(_unitOfWork.WorkoutRepository.AddWorkout(userId, _mapper.Map<Workout>(workout)));
            _unitOfWork.Save();
            return newWorkout;
        }

        public void DeleteWorkoutById(int workoutId)
        {
            _unitOfWork.WorkoutRepository.Delete(new Workout()
            {
                Id = workoutId
            });
            _unitOfWork.Save();
        }

        public AllWorkoutsResponseModel GetAllWorkouts(int userId)
        {
            var workouts = _unitOfWork.WorkoutRepository.GetAllWorkouts(userId);
            return new AllWorkoutsResponseModel()
            {
                Workouts = _mapper.Map<IEnumerable<WorkoutResponseModel>>(workouts)
            };
        }

        public WorkoutResponseModel? GetWorkoutById(int workoutId)
        {
            var workout = _unitOfWork.WorkoutRepository.FindByCondition(w => w.Id == workoutId).SingleOrDefault();

            return workout == null ? null : _mapper.Map<WorkoutResponseModel>(workout);
        }

        public WorkoutResponseModel? UpdateWorkout(int workoutId, WorkoutUpdateRequestModel workout)
        {
            var mapped = _mapper.Map<Workout>(workout);
            var w = _unitOfWork.WorkoutRepository.UpdateWorkout(workoutId, mapped);

            return _mapper.Map<WorkoutResponseModel>(w);
        }
    }
}
