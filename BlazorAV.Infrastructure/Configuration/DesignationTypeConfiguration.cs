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
    public class DesignationTypeConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.ToTable(nameof(Designation));
            builder.HasKey(p => p.DesignationId);
            builder.Property(p => p.DesignationDescription).HasMaxLength(250);
            builder.HasOne(p => p.Company).WithMany(p => p.Designations).HasForeignKey(p => p.CompanyId);
        }
    }
}
