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
    public class SystemAppConfiguration : IEntityTypeConfiguration<SystemApp>
    {
        public void Configure(EntityTypeBuilder<SystemApp> builder)
        {
            builder.Property(t=>t.Title).IsRequired().HasMaxLength(50);
        }
    }
}
