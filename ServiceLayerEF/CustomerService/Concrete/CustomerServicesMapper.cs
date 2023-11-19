using AutoMapper;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Server.DataLayer.Context;

namespace ServiceLayer.EF.CustomerService.Concrete
{
    public class CustomerServicesMapper
    {
        private readonly soContext _context;
        private readonly IMapper _mapper;

        public CustomerServicesMapper(soContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>?> GetAllAsync()
        {
            try
            {
                var query = _context.Customers;

                var data = await query.ToListAsync();

                if (data != null && data.Any())
                {
                    return _mapper.Map<List<Customer>, List<CustomerDto>>(data).AsQueryable();
                }

                return Enumerable.Empty<CustomerDto>();
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
                    // Use AutoMapper to map properties from objdto to customer
                    _mapper.Map(objdto, customer);

                    // Save changes to the database
                    var affectedRows = await _context.SaveChangesAsync();

                    // Return true if at least one row is affected, indicating a successful update
                    return affectedRows > 0;
                }

                // Customer with the specified ID not found
                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or rethrow if needed)
                string msg = ex.Message;
                return false;
            }
        }
        public async Task<bool> Insertsync(CustomerDto objdto)
        {

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id == objdto.Id);
                if (customer != null)
                {
                    return false;
                }             
                var obj = _mapper.Map<CustomerDto, Customer>(objdto);
                var addedObj = _context.Customers.Add(obj);
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

                var ocust = await _context.Customers.FirstOrDefaultAsync(u => u.Id== Id);


                if (ocust != null)
                {
                    return _mapper.Map<Customer, CustomerDto>(ocust);
                }

                return new CustomerDto();

      

            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }

        public async Task<bool> DeleteByIdAsync(int Id)
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
