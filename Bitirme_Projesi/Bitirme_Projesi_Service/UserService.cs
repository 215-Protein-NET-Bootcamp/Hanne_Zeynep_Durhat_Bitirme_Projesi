using Bitirme_Projesi_Base.Jwt;
using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Data.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Service
{
    public class UserService : IUserServices
    {
        IUserRepository _userRepository = null;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public UserService(IUserRepository userRepository, IOptions<JwtConfig> jwtconfig)
        {
            _userRepository = userRepository;
            _jwtConfig = jwtconfig.Value;
            _secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }


        public User Login(User oUser)
        {

            

            oUser.Password = BCrypt.Net.BCrypt.HashPassword(oUser.Password);

            Task<LoginResponse> loginResponse = _userRepository.LoginUser(oUser);

            if (loginResponse.Result == null)
                return new User();

     
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, oUser.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            User loginUser = new User();
            loginUser.Email = loginResponse.Result.EmailAddress;
            loginUser.Password = oUser.Password;
            loginUser.Token = tokenHandler.WriteToken(token);


            return loginUser;
        }



        public User Signup(User oUser)
        {
            oUser.Password = BCrypt.Net.BCrypt.HashPassword(oUser.Password);

            Task<AddUserResponse> userResponse = _userRepository.AddUserAsync(oUser);

            if (userResponse.Result == null)
                return new User();

            User savedUser = new User();
            savedUser.Email = userResponse.Result.EmailAddress;
            savedUser.Password = oUser.Password;

            return savedUser;
        }

    
    }

}

