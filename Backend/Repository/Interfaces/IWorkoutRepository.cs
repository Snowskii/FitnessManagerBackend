using Backend.Models;

namespace Backend.Repository.Interfaces
{
    public interface IWorkoutRepository : IRepositoryBase<Workout>
    {
        public IEnumerable<Workout> GetAllWorkouts(int userId);
        public Workout AddWorkout(int userId, Workout workout);

        public Workout UpdateWorkout(int workoutId, Workout workout);
    }
}
