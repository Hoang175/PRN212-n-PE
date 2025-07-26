using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Question2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var congfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(congfig.GetConnectionString("DBContext"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.DepartmentNavigation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Department);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.DepartmentNavigation)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.Department);
        }
    }
}
