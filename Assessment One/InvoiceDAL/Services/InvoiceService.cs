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
    public class InvoiceService : IInvoiceService
    {
        string commandText;
        string connectionString;

        public InvoiceService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["InvoiceConnection"].ConnectionString.ToString();
        }

        public List<Invoice> CreateOrUpdateInvoice(Invoice invoice)
        {
            int numberRowsAdded;

            if (invoice.Id == 0)
            {
                //This is a new invoice as the id is zero
                commandText = "Insert into dbo.Invoices (Customer_Id, Description, Cost, Payment_Date)" +
                                        "values(@Customer_Id, @Description, @Cost, @Payment_Date)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Customer_Id", SqlDbType.Int);
                    command.Parameters.Add("@Description", SqlDbType.VarChar);
                    command.Parameters.Add("@Cost", SqlDbType.Float);
                    command.Parameters.Add("@Payment_Date", SqlDbType.Date);

                    command.Parameters["Customer_Id"].Value = invoice.Customer_Id;
                    command.Parameters["Description"].Value = invoice.Description;
                    command.Parameters["Cost"].Value = invoice.Costs;
                    command.Parameters["Payment_Date"].Value = invoice.Payment_Date;

                    try
                    {
                        connection.Open();
                        numberRowsAdded = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                //The invoice id is not zero so we are updating an existing invoice
                commandText = "Update dbo.Invoices " +
                                "Set Customer_Id = @Customer_Id, " +
                                "Description = @Description, " +
                                "Cost = @Cost, " +
                                "Payment_Date = @Payment_Date " +
                                "Where Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters.Add("@Customer_Id", SqlDbType.Int);
                    command.Parameters.Add("@Description", SqlDbType.VarChar);
                    command.Parameters.Add("@Cost", SqlDbType.Float);
                    command.Parameters.Add("@Payment_Date", SqlDbType.Date);

                    command.Parameters["Id"].Value = invoice.Id;
                    command.Parameters["Customer_Id"].Value = invoice.Customer_Id;
                    command.Parameters["Description"].Value = invoice.Description;
                    command.Parameters["Cost"].Value = invoice.Costs;
                    command.Parameters["Payment_Date"].Value = invoice.Payment_Date;

                    try
                    {
                        connection.Open();
                        numberRowsAdded = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return ((IInvoiceService)this).GetCustomerInvoices(invoice.Customer_Id);
        }

        public List<Invoice> DeleteInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetCustomerInvoices(int Customer_Id)
        {
            List<Invoice> returnList = new List<Models.Invoice>();

            commandText = "select Id, Cost, Description, Payment_Date, Customer_Id " +
                            "from Invoices where IsDeleted = 0 and Customer_Id = @Customer_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Customer_Id", SqlDbType.Int);
                command.Parameters["@Customer_Id"].Value = Customer_Id;

                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    // write each record
                    while (reader.Read())
                    {
                        returnList.Add(new Invoice
                        {
                            Id = (int)reader["Id"],
                            //Costs = (float)reader["Cost"],
                            Description = (string)reader["Description"],
                            //Payment_Date = (DateTime)reader["Payment_Date"],
                            Customer_Id = (int)reader["Customer_Id"]
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

        public int GetMaxInvoiceId()
        {
            throw new NotImplementedException();
        }

        public List<Invoice> InvoiceExists(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> UpdateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
