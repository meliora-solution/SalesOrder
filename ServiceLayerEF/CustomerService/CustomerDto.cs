using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Dapper.CustomerService
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name  is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name  is required")]
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
