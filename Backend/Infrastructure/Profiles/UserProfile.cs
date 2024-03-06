using AutoMapper;
using Backend.Models;
using Backend.Models.ResponseModels;

namespace Backend.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserProfileResponseModel>();
            CreateMap<User, RegisterUserResponseModel>();
        }
    }
}
