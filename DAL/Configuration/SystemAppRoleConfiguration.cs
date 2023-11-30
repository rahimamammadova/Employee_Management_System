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
    public class SystemAppRoleConfiguration : IEntityTypeConfiguration<SystemAppRole>
    {
        public void Configure(EntityTypeBuilder<SystemAppRole> builder)
        {
            builder.Property(t => t.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(p => p.Permissions)
                .WithOne(s => s.SystemAppRole)
                .HasForeignKey(k => k.SystemAppRoleId);
        }
    }
}
