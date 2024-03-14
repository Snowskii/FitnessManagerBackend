using Backend.Repository;
using Backend.Repository.Interfaces;

namespace Backend.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDataContext dbContext;

        private IUserRepository _userRepository;

        private IWorkoutRepository _workoutRepository;

        private IExerciseRepository _exerciseRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(dbContext);
                }

                return _userRepository;
            }
        }

        public IWorkoutRepository WorkoutRepository
        {
            get
            {
                if (_workoutRepository == null)
                {
                    _workoutRepository = new WorkoutRepository(dbContext);
                }

                return _workoutRepository;
            }
        }

        public IExerciseRepository ExerciseRepository
        {
            get
            {
                if (_exerciseRepository == null)
                {
                    _exerciseRepository = new ExerciseRepository(dbContext);
                }

                return _exerciseRepository;
            }
        }

        public UnitOfWork(ApplicationDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
