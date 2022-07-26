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
    public class ClientTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client));
            builder.HasKey(p => p.ClientId);
            builder.Property(p => p.FirstName).HasMaxLength(250);
            builder.Property(p => p.Surname).HasMaxLength(250);
            builder.HasOne(p => p.Company).WithMany(p => p.Clients).HasForeignKey(p => p.CompanyId);
            builder.HasOne(p => p.Designation).WithMany(p => p.Clients).HasForeignKey(p => p.DesignationId);
            builder.HasOne(p => p.ProtectionType).WithMany(p => p.Clients).HasForeignKey(p => p.ProtectionTypeId);
        }
    }
}
