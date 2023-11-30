using EMS_DAL.DBModels;
using EMS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(256);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(g => g.GenderType).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Salary).HasPrecision(18, 2).IsRequired();
            builder.HasMany(e => e.SystemApps)
                .WithMany(e => e.Employees)
                .UsingEntity<EmployeeSystemApp>(
                s => s.HasOne(e => e.SystemApp).WithMany(e => e.EmployeeSystemApps).HasForeignKey(s=>s.SystemAppId),
                s => s.HasOne(e => e.Employee).WithMany(e => e.EmployeeSystemApps).HasForeignKey(e=>e.EmployeeId)
                );

        }
    }
}
