using Backend.Models;

namespace Backend.Repository.Interfaces
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        public IEnumerable<Exercise> GetAllExercises(int userId);
        public Exercise AddExerciseToUser(int userId, Exercise exercise);
    }
}
