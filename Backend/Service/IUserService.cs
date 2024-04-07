using Backend.Infrastructure.Authentication;
using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Service
{
    public interface IUserService
    {
        public UserProfileResponseModel GetUserProfile(int Id);

        public RegisterUserResponseModel RegisterUser(RegisterUserModel model, JwtOptions jwtOptions);

        public LoginResponseModel LoginUser(LoginUserModel model, JwtOptions jwtOptions);
    }
}
