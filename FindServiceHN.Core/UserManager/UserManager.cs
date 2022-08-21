using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;

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
              var user = this.userRepository.FirstOrDefault(x => x.UserName.Equals(model.Username) || x.Email.Equals(model.Username));

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

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = this.GetById(id);
                this.userRepository.Delete(user);
                await this.userRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                var userToEdit = this.GetById(user.Id);
                userToEdit.Email = user.Email;
                userToEdit.UserName = user.UserName;

                var result = this.userRepository.Update(userToEdit);
                await this.userRepository.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<User> CreateUserAsync(UserDTO user)
        {
            if (user != null)
            {
                var newUser = new User 
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = Role.User,
                };

                newUser.PasswordHash = BCryptNet.HashPassword(user.Password);
                var result = this.userRepository.Create(newUser);
                await this.userRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
