using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class VISDbContext : DbContext
    {
        public VISDbContext() 
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RITVIK\\SQLEXPRESS;database=VISDB;integrated security=true;Trusted_Connection=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial admin user
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {
                    EmailId = "admin@demo.com",
                    Password = "admin123"
                }
            );
        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<City> Cities { get; set; }


    }
}
