using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CategoryManager;
using FindServiceHN.Core.UserManager;
using FindServiceHn.Core.ServicesStatusManager;
using FindServiceHN.Core.Quotes_DetailManager;
using FindServiceHN.Core.ProvidersAttentionManager;
namespace FindServiceHn.API
{
    public static class Injection
    {
        public static void Inject(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(FindServiceHnRepositoryBase<>));
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IServicesStatusManager, ServicesStatusManager>();
            builder.Services.AddScoped<IQuotes_DetailManager, Quotes_DetailManager>();
            builder.Services.AddScoped<IProviders_AttentionManager, Providers_AttentionManager>();
            
        }
    }
}
