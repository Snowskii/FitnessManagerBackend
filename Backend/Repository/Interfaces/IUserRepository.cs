using backend.Models;
using backend.Models.RequestModels;
using backend.Models.ResponseModels;

namespace backend.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User RegisterUser(RegisterUserModel model);

        public User? LoginUser(LoginUserModel model);

    }
}
