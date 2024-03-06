using AutoMapper;
using backend.Models;
using backend.Models.ResponseModels;

namespace backend.Infrastructure.Profiles
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
