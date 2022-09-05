using FindServiceHn.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database
{
    public class FindServiceHnContext : DbContext
    {
        public FindServiceHnContext(DbContextOptions<FindServiceHnContext> options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProviderPlanJob> ProviderPlanJobs { get; set; }
        public DbSet<ProviderEval> ProviderEvals {get; set; }
        public DbSet<ServicesStatus>ServicesStatuss { get; set;}
        public DbSet<QuotesDetail> QuotesDetails {get; set;}
        public DbSet<QuotesHeader> QuotesHeaders {get; set;}
        public DbSet<ProvidersAttention> ProvidersAttentions {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderSatisfaction> Ordersatisfactions { get; set; }
        public DbSet<OrderStatus> Orderstatus { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Countries>  Countries { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<DayHour> DayHours { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(s => s.IdCategory);

            modelBuilder.Entity<Provider>()
                .HasKey(s => s.IdProvider);

            modelBuilder.Entity<ServicesStatus>()
                .HasKey(s => s.IdServicesStatus);

            modelBuilder.Entity<ProvidersAttention>()
                .HasKey(s => s.IdProviderAttention);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(s => s.IdOrder);

            modelBuilder.Entity<OrderSatisfaction>()
                .HasKey(s => s.IdSatisfaction);

            modelBuilder.Entity<OrderStatus>()
                .HasKey(s => s.IdStatusOrder);

            modelBuilder.Entity<QuotesHeader>()
                .HasKey(s => s.IdQuoteHeader);

            modelBuilder.Entity<QuotesDetail>()
                .HasKey(s => s.IdQuoteDetail);

            modelBuilder.Entity<Product>()
                .HasKey(s => s.IdProduct);

            modelBuilder.Entity<ProviderEval>()
                .HasKey(s => s.IdEval);

            modelBuilder.Entity<ProviderPlanJob>()
                .HasKey(s => s.IdQtyWorks);

            modelBuilder.Entity<ProviderService>()
                .HasKey(s => s.IdProviderService);

            modelBuilder.Entity<Customers>()
                .HasKey(s => s.IdCustomer);

            modelBuilder.Entity<CustomerAddress>()
                .HasKey(s => s.IdCustomerAddress);

            modelBuilder.Entity<Countries>()
                .HasKey(s => s.IdCountry);

            modelBuilder.Entity<Departments>()
                .HasKey(s => s.IdDepartment);

            modelBuilder.Entity<Municipalities>()
                .HasKey(s => s.IdMunicipality);

            modelBuilder.Entity<SubCategory>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<DayHour>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<OrderHeader>()
                .HasKey(s => s.IdOrder);
        }
    }
}
