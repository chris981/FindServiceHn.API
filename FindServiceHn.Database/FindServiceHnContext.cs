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
        public DbSet<Category> Categories { get; set; }
        public DbSet<ServicesStatus>ServicesStatuss { get; set;}
        public DbSet<QuotesDetail> QuotesDetails {get; set;}
        public DbSet<QuotesHeader> QuotesHeaders {get; set;}
        public DbSet<ProvidersAttention> ProvidersAttentions {get; set;}
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(s => s.IdCategory);
            modelBuilder.Entity<ServicesStatus>()
                .HasKey(s => s.IdServicesStatus);
            modelBuilder.Entity<QuotesDetails>()
                .HasKey(s => s.IdQuoteDetail);  
            modelBuilder.Entity<QuotesHeaders>()
                .HasKey(s => s.IdQuoteHeader);
            modelBuilder.Entity<ProvidersAttention>()
                .HasKey(s => s.IdProviderAttention);
                  
        }
    }
}
