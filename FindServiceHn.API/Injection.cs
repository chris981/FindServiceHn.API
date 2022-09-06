using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CategoryManager;
using FindServiceHN.Core.ProductManager;
using FindServiceHN.Core.OrderDetailManager;
using FindServiceHN.Core.OrderSatisfactionManager;
using FindServiceHN.Core.OrderStatusManager;
using FindServiceHN.Core.UserManager;
using FindServiceHN.Core.QuotesDetailManager;
using FindServiceHN.Core.QuotesHeaderManager;
using FindServiceHN.Core.ProvidersAttentionManager;
using FindServiceHN.Core.ServicesStatusManager;
using FindServiceHn.Core.ServicesStatusManager;
using FindServiceHN.Core.ProviderManager;
using FindServiceHN.Core.CountriesManager;
using FindServiceHN.Core.SubCategoriesManager;
using FindServiceHN.Core.DayHoursManager;
using FindServiceHN.Core.DepartmentsManager;
using FindServiceHN.Core.CustomerAddressManager;
using FindServiceHN.Core.CustomersManager;
using FindServiceHN.Core.MunicipalitiesManager;
using FindServiceHN.Core.OrderHeaderManager;

namespace FindServiceHn.API
{
    public static class Injection
    {
        public static void Inject(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(FindServiceHnRepositoryBase<>));
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();            
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<ICountriesManager, CountriesManager>();
            builder.Services.AddScoped<ICustomerAddressManager, CustomerAddressManager>();
            builder.Services.AddScoped<ICustomersManager, CustomersManager>();
            builder.Services.AddScoped<IDayHoursManager, DayHoursManager>();
            builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
            builder.Services.AddScoped<IMunicipalitiesManager, MunicipalitiesManager>();                                    
            builder.Services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            builder.Services.AddScoped<IOrderHeaderManager, OrderHeaderManager>();
            builder.Services.AddScoped<IOrderSatisfactionManager, OrderSatisfactionManager>();
            builder.Services.AddScoped<IOrderStatusManager, OrderStatusManager>();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProviderManager, ProviderManager>();
            builder.Services.AddScoped<IProvidersAttentionManager, ProvidersAttentionManager>();
            builder.Services.AddScoped<IQuotesDetailManager, QuotesDetailManager>();
            builder.Services.AddScoped<IQuotesHeaderManager, QuotesHeaderManager>();
            builder.Services.AddScoped<IServicesStatusManager, ServicesStatusManager>();
            builder.Services.AddScoped<ISubCategoriesManager, SubCategoriesManager>();
            builder.Services.AddScoped<IUserManager, UserManager>();
        }
    }
}
