using Backend.Models;
using Backend.Repository.Interfaces;

namespace Backend.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDataContext dbContext) : base(dbContext)
        {
        }

        public Exercise AddExerciseToUser(int userId, Exercise exercise)
        {
            exercise.UserId = userId;
            var newExercise = Create(exercise);
            ApplicationDataContext.SaveChanges();
            return newExercise;
        }

        public IEnumerable<Exercise> GetAllExercises(int userId)
        {
            return FindByCondition(e => e.UserId == userId);
        }
    }
}
