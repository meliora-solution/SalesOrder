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

        /*
         
        The line public CustomerServices(soContext context) is the constructor of the CustomerServices class. In this constructor, 
        a parameter of type soContext named context is defined. This constructor is used for dependency injection, as it takes an instance of 
        soContext as a parameter, allowing the caller to provide the necessary dependency (in this case, the soContext instance) when creating 
        an instance of the CustomerServices class.

        Dependency injection is a design pattern where the dependencies of a class are injected from the outside rather than being created within the class. 
        This promotes better separation of concerns and makes the class more testable and modular.
         
         */

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
                var sql = @"
                        MERGE INTO Customer AS target
                        USING (VALUES 
                            (@Id, @FirstName, @LastName, @City, @Country, @Phone)
                        ) AS source (Id, d2, d3, d4, d5, d6)
                        ON target.Id = source.Id
                        WHEN MATCHED THEN
                            UPDATE SET
                                target.FirstName = source.d2,
                                target.LastName = source.d3,
                                target.City = source.d4,
                                target.Country = source.d5,
                                target.Phone = source.d6
                        WHEN NOT MATCHED BY TARGET THEN
                            INSERT (FirstName, LastName, City, Country, Phone)
                            VALUES (source.d2, source.d3, source.d4, source.d5, source.d6);";

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
        public async Task<CustomerDto?> GetCustomerAsync(int Id)
        {
            try
            {
                string sql = "SELECT * FROM Customer WHERE Id = @Id";

                using (IDbConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    // Use QueryAsync<T> where T is the type you expect to retrieve
                    var query = await connection.QueryAsync<CustomerDto>(sql, new { Id });
                    var data = query.SingleOrDefault();
                    return data;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                string sql = "DELETE FROM Customer WHERE Id = @Id";

                using (IDbConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    // Use ExecuteAsync for non-query operations like delete
                    var affectedRows = await connection.ExecuteAsync(sql, new { Id });

                    // Check if any rows were affected
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }



    }
}
