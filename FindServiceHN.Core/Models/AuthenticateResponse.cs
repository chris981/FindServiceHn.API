using FindServiceHn.Database.Models;

namespace FindServiceHN.Core.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
            Token = token;
        }
    }
}
