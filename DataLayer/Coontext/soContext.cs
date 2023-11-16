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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKMINI\\MSSQLDEV;database=SampleDB;trusted_connection=true");
            }
        }

        /*  
        When you declare a property as virtual in an Entity Framework Core entity class, 
        it enables lazy loading for that navigation property.Lazy loading is a feature that allows related data to be loaded from 
        the database only when it is accessed for the first time.This can be beneficial in certain scenarios 
        to optimize performance and minimize the amount of data loaded initially.
        
        public virtual DbSet<Customer> Customer{ get; set; } = null!;
        
        ServiceLayer.EF needs DBSet but ServiceLayer.Dapper does not need them.

         */

        public virtual DbSet<Customer>? Customer { get; set; } 
        public DbSet<Supplier> Supplier { get; set; } 
        public DbSet<Order> Order { get; set; } 
        public DbSet<OrderItem> OrderItem { get; set; } 
        public DbSet<Product> Product { get; set; } 
    }
    
 }
    

