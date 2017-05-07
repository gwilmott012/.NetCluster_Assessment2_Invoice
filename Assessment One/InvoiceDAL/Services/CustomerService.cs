using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceDAL.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceDAL.Services
{
    public class CustomerService : ICustomerService
    {

        //var ctmp = ConfigurationManager.ConnectionStrings;
        string connectionString = "Data Source=.;Initial Catalog=Activity12Invoices;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["InvoiceConnection"].ConnectionString.ToString();

        List<Customer> ICustomerService.CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerService.CustomerExists(Customer customer)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerService.DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }




        List<Customer> ICustomerService.GetCustomers()
        {
            List<Customer> returnList = new List<Models.Customer>();

            string commandText = "Select Id, [Address], Name from Customers where IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    // write each record
                    while (reader.Read())
                    {
                        returnList.Add(new Customer { Id = (int)reader["Id"], Customer_Address = (string)reader["Address"], Customer_Name = (string)reader["Name"] });
                    }

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }

            }



            return returnList;

        }

        List<Customer> ICustomerService.GetCustomer(string customerName)
        {
            throw new NotImplementedException();
        }

        int ICustomerService.GetMaxCustomerId()
        {
            throw new NotImplementedException();
        }

        int ICustomerService.GetNumberOfCustomers()
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerService.UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
