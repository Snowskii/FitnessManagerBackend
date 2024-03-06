using backend.Repository.Interfaces;

namespace backend.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
