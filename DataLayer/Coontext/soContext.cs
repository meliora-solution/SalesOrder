using Microsoft.EntityFrameworkCore;
using System;

namespace Server.DataLayer.Context
{
    public partial class soContext : DbContext
    {
        public soContext(DbContextOptions<soContext> options) : base(options)
        {
        }
     
    }
    
 }
    

