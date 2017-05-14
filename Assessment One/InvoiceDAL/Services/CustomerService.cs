using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceDAL.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace InvoiceDAL.Services
{
    public class CustomerService : ICustomerService
    {

        string connectionString;
        string commandText;

        public CustomerService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["InvoiceConnection"].ConnectionString.ToString();
        }

        public List<Customer> CreateOrUpdateCustomer(Customer customer)
        {


            string commandText;

            if (customer.Id == 0)
            {
                //This is a new customer as the id is zero
                commandText = "Insert into dbo.Customers (Name, [Address]) " +
                                       "values(@Name, @Address)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Name", SqlDbType.VarChar);
                    command.Parameters.Add("@Address", SqlDbType.VarChar);

                    command.Parameters["@Name"].Value = customer.Customer_Name;
                    command.Parameters["@Address"].Value = customer.Customer_Address;

                    try
                    {
                        connection.Open();
                        int numberRowsAdded = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                }
            }
            else
            {
                //The customer id is not zero so we are updating an existing customer
                commandText = "Update dbo.Customers " +
                                "Set Name = @Name, " +
                                "[Address] = @Address " +
                                "Where ID = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters.Add("@Name", SqlDbType.VarChar);
                    command.Parameters.Add("@Address", SqlDbType.VarChar);

                    command.Parameters["@Id"].Value = customer.Id;
                    command.Parameters["@Name"].Value = customer.Customer_Name;
                    command.Parameters["@Address"].Value = customer.Customer_Address;

                    try
                    {
                        connection.Open();
                        int numberRowsAdded = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                }


            }

            return ((ICustomerService)this).GetCustomers();
        }

        public List<Customer> GetCustomers()
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
                        returnList.Add(new Customer
                        {
                            Id = (int)reader["Id"],
                            Customer_Address = (string)reader["Address"],
                            Customer_Name = (string)reader["Name"]
                        });
                    }

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }

            }

            return returnList;

        }

        public List<Customer> GetCustomerById(int customerId)
        {
            List<Customer> returnList = new List<Models.Customer>();

            commandText = "select Id, Cost, Description, Payment_Date, Customer_Id " +
                "from Invoices where IsDeleted = 0 and Id = @Customer_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Customer_Id", SqlDbType.Int);

                command.Parameters["@Customer_Id"].Value = customerId;

                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnList.Add(new Customer
                        {
                            Id = (int)reader["Id"],
                            Customer_Address = (string)reader["Address"],
                            Customer_Name = (string)reader["Name"]
                        });
                    }
                }
                catch (Exception)
                {

                }
            }

            return returnList;
        }

        public List<Customer> GetCustomer(string customerName)
        {
            List<Customer> returnList = new List<Models.Customer>();

            commandText = "select * from dbo.Customers where IsDeleted = 0 and Name like '%' + @Name + '%'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = customerName;


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
    }
}
