using AutoMapper;
using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Infrastructure.Profiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutResponseModel>();
            CreateMap<WorkoutRequestModel, Workout>();
        }
    }
}
