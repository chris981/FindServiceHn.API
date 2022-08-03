using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.UserManager;

namespace FindServiceHn.API
{
    public static class Injection
    {
        public static void Inject(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(FindServiceHnRepositoryBase<>));
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IUserManager, UserManager>();
        }
    }
}
