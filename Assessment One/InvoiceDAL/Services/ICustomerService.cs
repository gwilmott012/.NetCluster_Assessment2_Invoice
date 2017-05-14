using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Services
{

    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        List<Customer> CreateOrUpdateCustomer(Customer customer);
        List<Customer> GetCustomer(string customerName);
        List<Customer> GetCustomerById(int customerId);
    }
}
