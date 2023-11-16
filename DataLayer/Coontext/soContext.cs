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

        /*  
        When you declare a property as virtual in an Entity Framework Core entity class, 
        it enables lazy loading for that navigation property.Lazy loading is a feature that allows related data to be loaded from 
        the database only when it is accessed for the first time.This can be beneficial in certain scenarios 
        to optimize performance and minimize the amount of data loaded initially.
        
        public virtual DbSet<Customer> Customer{ get; set; } = null!;
        
        ServiceLayer.EF needs DBSet but ServiceLayer.Dapper does not need them.
         */
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Supplier> Supplier { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderItem> OrderItem { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
    }

    
}
