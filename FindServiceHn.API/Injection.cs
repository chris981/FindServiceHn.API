using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CategoryManager;
using FindServiceHN.Core.OrderDetailManager;
using FindServiceHN.Core.OrderSatisfactionManager;
using FindServiceHN.Core.OrderStatusManager;
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
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            builder.Services.AddScoped<IOrderSatisfactionManager, OrderSatisfactionManager>();
            builder.Services.AddScoped<IOrderStatusManager, OrderStatusManager>();
        }
    }
}
