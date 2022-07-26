using BlazorAV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Infrastructure.Configuration
{
    public class ProtectionTypeConfiguration : IEntityTypeConfiguration<ProtectionType>
    {
        public void Configure(EntityTypeBuilder<ProtectionType> builder)
        {
            builder.ToTable(nameof(ProtectionType));
            builder.HasKey(p => p.ProtectionId);
            builder.Property(p => p.ProtectionDescription).HasMaxLength(250);
            builder.HasOne(p => p.Company).WithMany(p => p.ProtectionTypes).HasForeignKey(p => p.CompanyId);
        }
    }
}
