using AutoMapper;
using Backend.Models;
using Backend.Models.ResponseModels;

namespace Backend.Infrastructure.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseResponseModel>();
        }
    }
}
