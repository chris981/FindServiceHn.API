using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using Microsoft.Extensions.Options;
using BCrypt.Net;

namespace FindServiceHN.Core.UserManager
{
    public class UserManager : IUserManager
    {
        private IRepository<User> userRepository;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserManager(
            IRepository<User> userRepository,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
              var user = this.userRepository.FirstOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userRepository.All();
        }

        public User GetById(int id)
        {
            var user = this.userRepository.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
