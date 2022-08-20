﻿using FindServiceHn.Database.Models;
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
        public DbSet <Provider> Providers { get; set; }
        public DbSet <ProviderService> Provider_Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProviderPlanJob> Provider_Plan_Jobs { get; set; }
        public DbSet<ProviderEval> provider_Evals {get; set; }
        public DbSet<ServicesStatus>ServicesStatuss { get; set;}
        public DbSet<QuotesDetail> QuotesDetails {get; set;}
        public DbSet<QuotesHeader> QuotesHeaders {get; set;}
        public DbSet<ProvidersAttention> ProvidersAttentions {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> Order_Details { get; set; }
        public DbSet<OrderSatisfaction> Order_satisfactions { get; set; }
        public DbSet<OrderStatus> Order_status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(s => s.IdCategory);
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
                .HasKey(s => s.Id);
        }
    }
}
