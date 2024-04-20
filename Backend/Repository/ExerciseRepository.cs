using Backend.Models;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDataContext dbContext) : base(dbContext) { }

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

        public Exercise UpdateExercise(int exerciseId, Exercise updatedExercise)
        {
            var foundExercise = ApplicationDataContext
                .Exercises
                .SingleOrDefault(e => e.Id == exerciseId);

            if (foundExercise == null)
            {
                throw new Exception($"Exercise with ID: {exerciseId} couldnt be found.");
            }

            foundExercise.Name = updatedExercise.Name;
            foundExercise.Sets = updatedExercise.Sets;
            foundExercise.UserId = updatedExercise.UserId;
            foundExercise.TypeAmount = updatedExercise.TypeAmount;
            foundExercise.Type = updatedExercise.Type;

            ApplicationDataContext.SaveChanges();

            return foundExercise;
        }
    }
}
