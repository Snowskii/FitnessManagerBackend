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
            var newExercise = _mapper.Map<ExerciseResponseModel>(_unitOfWork.ExerciseRepository.AddExerciseToUser(userId, _mapper.Map<Exercise>(exercise)));
            _unitOfWork.Save();
            return newExercise;
        }

        public void DeleteExerciseById(int exerciseId)
        {
            _unitOfWork.ExerciseRepository.Delete(new Exercise()
            {
                Id = exerciseId
            });
            _unitOfWork.Save();
        }

        public AllExercisesResponseModel GetAllExercises(int userId)
        {
            var exercises = _unitOfWork.ExerciseRepository.GetAllExercises(userId);
            return new AllExercisesResponseModel()
            {
                Exercises = _mapper.Map<IEnumerable<ExerciseResponseModel>>(exercises)
            };
        }

        public ExerciseResponseModel? UpdateExercise(int exerciseId, ExerciseUpdateRequestModel exercise)
        {
            var mapped = _mapper.Map<Exercise>(exercise);
            var e = _unitOfWork.ExerciseRepository.UpdateExercise(exerciseId, mapped);

            return _mapper.Map<ExerciseResponseModel>(e);
        }
    }
}
