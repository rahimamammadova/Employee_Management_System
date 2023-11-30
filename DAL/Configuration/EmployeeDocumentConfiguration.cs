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
    public class EmployeeDocumentConfiguration: IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder) {
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.HasOne(x => x.Employee)
                    .WithMany(x => x.EmployeeDocuments)
                    .HasForeignKey(x => x.EmployeeId);
        }
    }
}
