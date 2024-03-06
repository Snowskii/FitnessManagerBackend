using AutoMapper;
using backend.Infrastructure;
using backend.Infrastructure.Authentication;
using backend.Models;
using backend.Models.RequestModels;
using backend.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserProfileResponseModel GetUserProfile(int Id)
        {
            var user = _unitOfWork.UserRepository.FindByCondition(user => user.Id == Id).SingleOrDefault();
            if (user == null)
            {
                return new UserProfileResponseModel();
            }

            return _mapper.Map<UserProfileResponseModel>(user);
        }

        public LoginResponseModel LoginUser(LoginUserModel model, JwtOptions jwtOptions)
        {
            var user = _unitOfWork.UserRepository.LoginUser(model);
            if (user == null)
            {
                return new LoginResponseModel() { Token = null};
            }
            var jwtToken = CreateAccessToken(jwtOptions, user, TimeSpan.FromMinutes(60));

            return new LoginResponseModel() {Token = jwtToken};
        }

        public RegisterUserResponseModel RegisterUser(RegisterUserModel model)
        {
            var registeredUser = _unitOfWork.UserRepository.RegisterUser(model);
            _unitOfWork.Save();

            return _mapper.Map<RegisterUserResponseModel>(registeredUser);
        }

        private string CreateAccessToken(JwtOptions jwtOptions,
            User user,
            TimeSpan expiration)
        {
            var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("aud", jwtOptions.Audience)
            };

            //var roleClaims = permissions.Select(x => new Claim("role", x));
            //claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.Add(expiration),
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);

            return rawToken;
        } 
    }
}
