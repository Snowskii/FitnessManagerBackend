using Backend.Infrastructure;
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

        [HttpGet]
        [Route("")]
        [Authorize]
        public ActionResult<AllExercisesResponseModel?> GetAllUserExercises()
        {
            var userId = Utils.getUserId(HttpContext.User.Identity as ClaimsIdentity);
            if (userId == null)
            {
                return NotFound();
            }
            return _exerciseService.GetAllExercises((int)userId);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public ActionResult<ExerciseResponseModel?> AddExerciseToUser(ExerciseRequestModel exercise)
        {
            var userId = Utils.getUserId(HttpContext.User.Identity as ClaimsIdentity);
            if (userId == null)
            {
                return NotFound();
            }
            return _exerciseService.AddExerciseToUser((int) userId, exercise);
        }

        [HttpDelete]
        [Route("{exerciseId:int}")]
        [Authorize]
        public IActionResult DeleteExerciseById(int exerciseId)
        {
            try
            {
                _exerciseService.DeleteExerciseById(exerciseId);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("{exerciseId:int}")]
        [Authorize]
        public ActionResult<ExerciseResponseModel?> UpdateExercise(int exerciseId, ExerciseUpdateRequestModel exercise)
        {
            var updatedExercise = _exerciseService.UpdateExercise(exerciseId, exercise);
            return updatedExercise == null ? NotFound() : updatedExercise;
        }
    }
}
