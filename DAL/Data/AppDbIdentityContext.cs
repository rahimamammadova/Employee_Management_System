using EMS_DAL.Configuration;
using EMS_DAL.DBModels;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Data
{
    public class AppDbIdentityContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbIdentityContext(DbContextOptions<AppDbIdentityContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<EmployeeSystemApp> EmployeeSystemApps { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<SystemApp> SystemApps { get; set; }
        public DbSet<SystemAppRole> SystemAppRoles { get; set; }
    }
}
