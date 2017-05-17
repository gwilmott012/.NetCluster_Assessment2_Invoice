using InvoiceDAL.Models;
using System.Collections.Generic;

namespace InvoiceDAL.Services
{

    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        List<Customer> CreateOrUpdateCustomer(Customer customer);
        List<Customer> GetCustomer(string customerName);
        List<Customer> GetCustomerById(int customerId);
        int GetMaxCustomerId();
        void DeleteCustomerById(int customerId);
    }
}
