using Dapper;
using DataLayer.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.DataLayer.Context;
using System.Data;

namespace ServiceLayer.Dapper.CustomerService.Concrete
{
    public class CustomerServices
    {
        private readonly soContext _context;

        public CustomerServices(soContext context)
        {
            _context = context;
        }

        // Menggunakan Dapper
        public async Task<IEnumerable<CustomerDto>> GetCustomerListAsync()
        {
            string sql = "SELECT * FROM Customer ";

            try
            {
                using (IDbConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {

                    var query = await connection.QueryAsync<Customer>(sql, new { });
                    var data = query.ToList();

                    // Manually map Customer to CustomerDto
                    var result = data.Select(customer => new CustomerDto
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        City = customer.City,
                        Country = customer.Country,
                        Phone = customer.Phone

                    }).ToList();

                    return result.AsQueryable();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

        }
        public async Task<bool> UpsertCustomerAsync(CustomerDto objdto)
        {
            try
            {
                var sql = @" MERGE INTO Customer  as t Using  (VALUES 
                    (@FirstName,@LastName,@City,@Country,@Phone))
                    as s (d1,d2,d3,d4,d5)
                    on t.FirstName = s.d1 and t.LastName=s.d2  
                    when matched then
                     update set FirstName=s.d1,LastName=s.d2,City=s.d3,Country=s.d4,Phone=s.d5
                     WHEN NOT MATCHED BY TARGET THEN  
                    Insert (FirstName,LastName,City,Country,Phone)
                    Values (s.d1,s.d2,s.d3,s.d4,s.d5);";

                using (IDbConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    var query = await connection.QueryAsync<string>(sql, objdto);
                }
                  
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }

    


    }
}
