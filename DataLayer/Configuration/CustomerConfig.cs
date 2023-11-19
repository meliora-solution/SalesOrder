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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {

            entity.ToTable("Customer");

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "IndexCustomerName");

            entity.Property(e => e.City).HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(40);

            entity.Property(e => e.FirstName).HasMaxLength(40);

            entity.Property(e => e.LastName).HasMaxLength(40);

            entity.Property(e => e.Phone).HasMaxLength(20);

        }
    }

}
