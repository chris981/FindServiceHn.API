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
        public DbSet <Provider> Providers { get; set; }
        public DbSet <Provider_service> Provider_Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider_plan_job> Provider_Plan_Jobs { get; set; }
        public DbSet<Provider_eval> provider_Evals {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(s => s.IdCategory);
        }
    }
}
