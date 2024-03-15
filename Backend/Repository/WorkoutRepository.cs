using Backend.Models;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(ApplicationDataContext dbContext) : base(dbContext)
        {
        }

        public Workout AddWorkout(int userId, Workout workout)
        {
            workout.UserId = userId;
            var createdWorkout = Create(workout);
            ApplicationDataContext.SaveChanges();
            return createdWorkout;
        }

        public IEnumerable<Workout> GetAllWorkouts(int userId)
        {
            return FindByCondition(u => u.UserId == userId);
        }
    }
}
