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
            var x = ApplicationDataContext
                .Workouts
                .Include(w => w.Exercises)
                .Where(w => w.UserId == userId);
            return x;
        }

        public Workout UpdateWorkout(int workoutId, Workout workout)
        {
            var work = ApplicationDataContext
                .Workouts
                .Include(w => w.Exercises)
                .SingleOrDefault(w => w.Id == workoutId);

            if (work == null)
            {
                throw new Exception("fdsaf");
            }

            work.Exercises.Clear();
            var x = workout.WorkoutsExercises.Select(w => w.ExerciseId);
            work.Exercises.AddRange(ApplicationDataContext.Exercises.Where(w => x.Contains(w.Id)));

            work.Description = workout.Description;
            work.Name = workout.Name;

            ApplicationDataContext.SaveChanges();

            return work;
        }
    }
}
