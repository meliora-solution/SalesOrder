using DataLayer.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configuration
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.ToTable("Supplier");

            entity.HasIndex(e => e.Country, "IndexSupplierCountry");

            entity.HasIndex(e => e.CompanyName, "IndexSupplierName");

            entity.Property(e => e.City).HasMaxLength(40);

            entity.Property(e => e.CompanyName).HasMaxLength(40);

            entity.Property(e => e.ContactName).HasMaxLength(50);

            entity.Property(e => e.ContactTitle).HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(40);

            entity.Property(e => e.Fax).HasMaxLength(30);

            entity.Property(e => e.Phone).HasMaxLength(30);


        }

    }
}
