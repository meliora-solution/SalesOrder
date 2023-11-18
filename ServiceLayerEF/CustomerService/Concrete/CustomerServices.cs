using Microsoft.EntityFrameworkCore;
using Server.DataLayer.Context;
using System.Data;

namespace ServiceLayer.EF.CustomerService.Concrete
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

        // Menggunakan Entity Framework.
        public async Task<IEnumerable<CustomerDto>?> GetCustomerListAsync()
        {
            try
            {
                var query = (from c in _context.Customers
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
        public async Task<bool> UpsertCustomerAsync(CustomerDto objdto)
        {
            try
            {


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

                return null;

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
                return false;

            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }


    }




}
