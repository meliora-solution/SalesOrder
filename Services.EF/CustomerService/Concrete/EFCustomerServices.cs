using DataLayer.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.DataLayer.Context;
using System.Data;

namespace ServiceLayer.EF.CustomerService.Concrete
{
    public class EFCustomerServices
    {
        private soContext _context;

        public EFCustomerServices(soContext context)
        {
            _context = context;
        }


        // Menggunakan Entity Framework.
        public async Task<IEnumerable<CustomerDto>?> GetEFCustomerListAsync()
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
//using (IDbConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
//{

//    var query = await connection.QueryAsync<Customer>(sql, new { });
//    var data = query.ToList();

//    // Manually map Customer to CustomerDto
//    var result = data.Select(customer => new CustomerDto
//    {
//        Id = customer.Id,
//        FirstName = customer.FirstName,
//        LastName = customer.LastName,
//        City = customer.City,
//        Country = customer.Country,
//        Phone = customer.Phone

//    }).ToList();

//    return result.AsQueryable();
//}