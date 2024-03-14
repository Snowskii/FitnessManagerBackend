using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        private int? getUserId(ClaimsIdentity identity) => identity == null ? null : Convert.ToInt32(identity.FindFirst("id").Value);

        [HttpGet]
        [Route("")]
        [Authorize]
        public AllWorkoutsResponseModel GetAllUserWorkouts()
        {
            var userId = getUserId(HttpContext.User.Identity as ClaimsIdentity);
            if (userId == null)
            {
                HttpContext.Response.StatusCode = 401;
                return null;
            }
            return _workoutService.GetAllWorkouts((int) userId);
        }

        [HttpGet]
        [Route("{workoutId:int}")]
        [Authorize]

        public ActionResult<WorkoutResponseModel> GetWorkoutById(int workoutId)
        {
            var workout = _workoutService.GetWorkoutById(workoutId);
            return workout == null ? NotFound() : workout;
        }

        [HttpPost]
        [Route("")]
        [Authorize]

        public WorkoutResponseModel AddWorkout(WorkoutRequestModel workout)
        {
            var userId = getUserId(HttpContext.User.Identity as ClaimsIdentity);
            if (userId == null)
            {
                HttpContext.Response.StatusCode = 401;
                return null;
            }
            return _workoutService.AddWorkout((int) userId, workout);
        }

        [HttpDelete]
        [Route("{workoutId:int}")]
        [Authorize]
        
        public IActionResult DeleteWorkoutById(int workoutId)
        {
            try
            {
                _workoutService.DeleteWorkoutById(workoutId);
            } catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
