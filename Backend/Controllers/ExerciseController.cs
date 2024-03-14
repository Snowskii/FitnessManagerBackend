using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        private int? getUserId(ClaimsIdentity identity) => identity == null ? null : Convert.ToInt32(identity.FindFirst("id").Value);


        [HttpGet]
        [Route("")]
        [Authorize]
        public AllExercisesResponseModel GetAllUserExercises()
        {
            var userId = getUserId(HttpContext.User.Identity as ClaimsIdentity);
            if (userId == null)
            {
                HttpContext.Response.StatusCode = 401;
                return null;
            }
            return _exerciseService.GetAllExercises((int)userId);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public ExerciseResponseModel AddExerciseToUser(int userId, ExerciseRequestModel exercise)
        {
            return _exerciseService.AddExerciseToUser(userId, exercise);
        }

        //[HttpDelete]
        //[Route("{exerciseId:int}")]
        //[Authorize]
        //public IActionResult DeleteExerciseById(int exerciseId) {
        //    try
        //    {
        //        _exerciseService.DeleteExerciseById(exerciseId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //    return Ok();
        //}
    }
}
