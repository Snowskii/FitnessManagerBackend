using backend.Infrastructure.Authentication;
using backend.Models.RequestModels;
using backend.Models.ResponseModels;
using backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId:int}")]
        [Authorize]
        public UserProfileResponseModel GetProfile(int userId)
        {
            return _userService.GetUserProfile(userId);
        }
        [HttpPost]
        [Route("register")]
        public RegisterUserResponseModel RegisterUser(RegisterUserModel model)
        {
            return _userService.RegisterUser(model);
        }

        [HttpPost]
        [Route("login")]
        public LoginResponseModel LoginUser(LoginUserModel model, JwtOptions jwtOptions)
        {
            var response = _userService.LoginUser(model, jwtOptions);

            return response;
        }
    }
}
