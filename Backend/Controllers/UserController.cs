using Backend.Infrastructure.Authentication;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
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
        public ActionResult<RegisterUserResponseModel> RegisterUser(RegisterUserModel model, JwtOptions jwtOptions)
        {
            try
            {
                return _userService.RegisterUser(model, jwtOptions);
            } catch { 
                return BadRequest("You are already registered.");
            }
            
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
