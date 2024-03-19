using AutoMapper;
using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Infrastructure.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseResponseModel>();
            CreateMap<ExerciseRequestModel, Exercise>();
            CreateMap<ExerciseC, Exercise>();
        }
    }
}
