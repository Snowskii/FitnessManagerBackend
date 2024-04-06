using Backend.Models;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Exercise UpdateExercise(int exerciseId, Exercise exercise)
        {
            var exer = ApplicationDataContext
                .Exercises
                .SingleOrDefault(e => e.Id == exerciseId);

            if (exer == null)
            {
                throw new Exception("Couldnt be found");
            }

            exer.Name = exercise.Name;
            exer.Sets = exercise.Sets;
            exer.UserId = exercise.UserId;
            exer.TypeAmount = exercise.TypeAmount;
            exer.Type = exercise.Type;

            ApplicationDataContext.SaveChanges();

            return exer;
        }
    }
}
