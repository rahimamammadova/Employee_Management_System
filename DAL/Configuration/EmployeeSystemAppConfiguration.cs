using EMS_DAL.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Configuration
{
    public class EmployeeSystemAppConfiguration:IEntityTypeConfiguration<EmployeeSystemApp>
    {
        public void Configure(EntityTypeBuilder<EmployeeSystemApp> builder)
        {
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x=>x.SystemAppId).IsRequired();
        }
    }
}
