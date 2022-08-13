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
        public DbSet<Order_detail> Order_Details { get; set; }
        public DbSet<Order_satisfaction> Order_satisfactions { get; set; }
        public DbSet<Order_status> Order_status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(s => s.IdCategory);
            modelBuilder.Entity<Order_detail>()
                .HasKey(s => s.IdOrder);
            modelBuilder.Entity<Order_satisfaction>()
                .HasKey(s => s.IdSatisfaction);
            modelBuilder.Entity<Order_status>()
                .HasKey(s => s.IdStatusOrder);
        }
    }
}
