using Backend.Models;
using Backend.Models.RequestModels;
using Backend.Models.ResponseModels;

namespace Backend.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User? RegisterUser(RegisterUserModel model);

        public User? LoginUser(LoginUserModel model);

    }
}
