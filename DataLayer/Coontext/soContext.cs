using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Server.DataLayer.Context
{
    public partial class soContext : DbContext
    {
        public soContext(DbContextOptions<soContext> options) : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }

}


