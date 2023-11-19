using DataLayer.Entity;
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

        public async Task<IEnumerable<CustomerDto>?> GetAllAsync()
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
        public async Task<bool> UpdateAsync(CustomerDto objdto)
        {

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id == objdto.Id);

                if (customer != null)
                {
                    customer.FirstName = objdto.FirstName;
                    customer.LastName = objdto.LastName;
                    customer.City = objdto.City;
                    customer.Country = objdto.Country;
                    customer.Phone = objdto.Phone;

                    var affectedRows = await _context.SaveChangesAsync();
                    return affectedRows > 0;

                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
        public async Task<bool> Insertsync(CustomerDto objdto)
        {

            try
            {

                var itemToAdd = new Customer
                {

                    FirstName = objdto.FirstName,
                    LastName = objdto.LastName,
                    City = objdto.City,
                    Country = objdto.Country,
                    Phone = objdto.Phone

                };
                _context.Add(itemToAdd);

                var affectedRows = await _context.SaveChangesAsync();
                return (affectedRows > 0);


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
        public async Task<bool> UpsertAsync(CustomerDto objdto)
        {

          
            try
            {
                //if (objdto.Id == 0)
                //{
                //    result = await Insertsync(objdto);
                //}
                //else
                //{
                //    result = await UpdateAsync(objdto);
                //}
               
               // this code is the sames as above > it is a shorter version.

               bool result = (objdto.Id == 0) ? await Insertsync(objdto) : await UpdateAsync(objdto);
               
               return result;


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
        public async Task<CustomerDto?> GetByIdAsync(int Id)
        {

            try
            {
                var query = (from o in _context.Customers
                             where o.Id == Id
                             select new CustomerDto
                             {
                                 Id = o.Id,
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 Phone = o.Phone,
                                 City = o.City,
                                 Country = o.Country
                             });

                var data = query.SingleOrDefault();
                return data;

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
                var itemToDelete = await _context.Customers.FindAsync(Id);
                _context.Customers.Remove(itemToDelete);

                var affectedRows = await _context.SaveChangesAsync();

                return (affectedRows > 0);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }


    }




}
