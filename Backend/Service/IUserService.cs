using backend.Infrastructure.Authentication;
using backend.Models;
using backend.Models.RequestModels;
using backend.Models.ResponseModels;

namespace backend.Service
{
    public interface IUserService
    {
        public UserProfileResponseModel GetUserProfile(int Id);

        public RegisterUserResponseModel RegisterUser(RegisterUserModel model);

        public LoginResponseModel LoginUser(LoginUserModel model, JwtOptions jwtOptions);
    }
}
