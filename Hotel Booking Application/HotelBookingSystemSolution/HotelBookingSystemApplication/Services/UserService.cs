using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using HotelBookingSystemApplication.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace HotelBookingSystemApplication.Repositories
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> userRepository;
        private readonly ITokenService tokenService;

        public UserService(IRepository<string, User> _userRepository,ITokenService _tokenService)
        {
            userRepository = _userRepository;
            tokenService = _tokenService;
        }
        public UserLoginDTO Login(UserLoginDTO login)
        {
            var user = userRepository.GetById(login.Email);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
                for (int i = 0; i < userPassword.Length; i++)
                {
                    if (userPassword[i] != user.Password[i])
                        return null;
                }
                login.Role = user.Role;
                login.Token = tokenService.GetToken(login);
                login.Password = "";
                return login;
            }
            return null;
        }

        public UserRegisterDTO Register(UserRegisterDTO register)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                UserName = register.UserName,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                Key = hmac.Key,
                Role = register.Role
            };
            var result = userRepository.Add(user);
            if(result != null)
            {
                register.Token = tokenService.GetToken(register);
                register.Password = "";
                register.RetypePassword = "";
                
                return register;
            }
            return null;
        }
    }
}
