using DataLayer.Configuration;
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
        public soContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You dont need this >> we configured it in program.cs
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("server=\\SQLinstanceName;database=SalesOrder;trusted_connection=true");
            }
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
 }
    

