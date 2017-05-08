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
        List<Customer> UpdateCustomer(Customer customer);
        List<Customer> DeleteCustomer(Customer customer);
        int GetNumberOfCustomers();
        int GetMaxCustomerId();
        List<Customer> CustomerExists(Customer customer);
        List<Customer> CreateOrUpdateCustomer(Customer customer);
        List<Customer> GetCustomer(string customerName);
    }
}
