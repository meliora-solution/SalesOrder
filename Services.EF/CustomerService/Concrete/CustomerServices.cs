using Microsoft.EntityFrameworkCore;
using Server.DataLayer.Context;
using System.Data;

namespace ServiceLayer.EF.CustomerService.Concrete
{
    public class CustomerServices
    {
        private readonly soContext _context;

        public CustomerServices(soContext context)
        {
            _context = context;
        }


        // Menggunakan Entity Framework.
        public async Task<IEnumerable<CustomerDto>?> GetCustomerListAsync()
        {
            try
            {
                var query = (from c in _context.Customer
                             select new CustomerDto
                             {
                                 Id = c.Id,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 City = c.City,
                                 Country = c.Country,
                                 Phone = c.Phone
                             });
                var data = await query.ToListAsync();
                return data.AsQueryable();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }


    }
}
