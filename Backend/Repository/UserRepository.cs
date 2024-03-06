using backend.Models;
using backend.Models.RequestModels;
using backend.Repository.Interfaces;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace backend.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository 
    {
        public UserRepository(ApplicationDataContext dbContext): base(dbContext)
        {

        }

        public User? LoginUser(LoginUserModel model)
        {
            var user = FindByCondition(user => user.Email == model.Email).SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            var hasher = new PasswordHasher<User>();
            var verification = hasher.VerifyHashedPassword(user, user.Password, model.Password);

            return verification == PasswordVerificationResult.Failed ? null : user;
        }

        public User RegisterUser(RegisterUserModel model)
        {
            var hasher = new PasswordHasher<RegisterUserModel>();
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                Password = hasher.HashPassword(model, model.Password),
            };
            user = Create(user);
            return user;
        }
    }
}
