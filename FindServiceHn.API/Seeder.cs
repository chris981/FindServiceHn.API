using FindServiceHn.Database;
using FindServiceHn.Database.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace FindServiceHn.API
{
    public static class Seeder
    {
        public static void Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<FindServiceHnContext>();

            if (!dataContext.Users.Any())
            {
                var testUsers = new List<User>
                {
                    new User { Id = 1, Email = "admin@admin.com", Name="admin Name", LastName="Admin LName", UserName = "admin", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin },
                    new User { Id = 2, Email = "user@admin.com", Name="user Name", LastName="User LName", UserName = "user", PasswordHash = BCryptNet.HashPassword("user"), Role = Role.User }
                };

                dataContext.Users.AddRange(testUsers);
                dataContext.SaveChanges();
            }
        }
    }
}
