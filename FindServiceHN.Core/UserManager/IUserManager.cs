using FindServiceHn.Database.Models;
using FindServiceHN.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.UserManager
{
    public interface IUserManager
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        Task<User> CreateUserAsync(UserDTO user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(User user);
        User GetById(int id);
    }
}
