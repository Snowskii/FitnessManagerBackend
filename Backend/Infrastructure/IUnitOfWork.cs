using Backend.Repository.Interfaces;

namespace Backend.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IWorkoutRepository WorkoutRepository { get; }
        void Save();
    }
}
