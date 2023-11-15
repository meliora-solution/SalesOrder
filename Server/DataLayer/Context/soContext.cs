using Microsoft.EntityFrameworkCore;

namespace Server.DataLayer.Context
{
    public class soContext : DbContext
    {
        public soContext(DbContextOptions<soContext> options) : base(options)
        {
        }
    }
}
