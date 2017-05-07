using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
    }
}
