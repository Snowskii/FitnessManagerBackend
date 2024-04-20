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
            var workouts = ApplicationDataContext
                .Workouts
                .Include(workout => workout.Exercises)
                .Where(workout => workout.UserId == userId);
            return workouts;
        }

        public Workout UpdateWorkout(int userId, int workoutId, Workout updatedWorkout)
        {
            var foundWorkout = ApplicationDataContext
                .Workouts
                .Include(w => w.Exercises)
                .SingleOrDefault(w => w.Id == workoutId);

            if (foundWorkout == null)
            {
                throw new Exception($"Workout with ID: {workoutId} couldnt be found.");
            }

            foundWorkout.Exercises.Clear();
            var exerciseIds = updatedWorkout.WorkoutsExercises.Select(workout => workout.ExerciseId);
            foundWorkout.Exercises
                .AddRange(ApplicationDataContext.Exercises
                .Where(e => exerciseIds.Contains(e.Id)));

            foundWorkout.Description = updatedWorkout.Description;
            foundWorkout.Name = updatedWorkout.Name;

            ApplicationDataContext.SaveChanges();

            return foundWorkout;
        }
    }
}
