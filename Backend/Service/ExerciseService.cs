using AutoMapper;
using Backend.Infrastructure;
using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Service
{
    public class ExerciseService : IExerciseService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ExerciseResponseModel AddExerciseToUser(int userId, ExerciseRequestModel exercise)
        {
            var newWorkout = _mapper.Map<ExerciseResponseModel>(_unitOfWork.ExerciseRepository.AddExerciseToUser(userId, _mapper.Map<Exercise>(exercise)));
            _unitOfWork.Save();
            return newWorkout;
        }

        public AllExercisesResponseModel GetAllExercises(int userId)
        {
            var exercises = _unitOfWork.ExerciseRepository.GetAllExercises(userId);
            return new AllExercisesResponseModel()
            {
                Exercises = _mapper.Map<IEnumerable<ExerciseResponseModel>>(exercises)
            };
        }
    }
}
