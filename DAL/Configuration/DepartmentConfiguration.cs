using EMS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Configuration
{
    public class DepartmentConfiguration:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(t => t.Title).IsRequired().HasMaxLength(128);
            builder.HasMany(e=>e.Employees)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId)
                .IsRequired();
        }

    }
}
