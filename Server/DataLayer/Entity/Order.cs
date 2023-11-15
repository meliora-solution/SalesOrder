using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate{ get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId{ get; set; }  
        public decimal TotalAmount { get; set; }
    }
}
