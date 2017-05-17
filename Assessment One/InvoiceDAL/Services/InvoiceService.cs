using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceDAL.Services
{
    public class InvoiceService : IInvoiceService
    {
        string commandText;
        string connectionString;
        string errorMessage;

        public InvoiceService()
        {
            errorMessage = ConfigurationManager.AppSettings["databaseErrorMessage"];
            connectionString = ConfigurationManager.ConnectionStrings["InvoiceConnection"].ConnectionString.ToString();
        }

        public List<Invoice> CreateOrUpdateInvoice(Invoice invoice)
        {
            int numberRowsAdded;

            if (invoice.CreateOrUpdate == true)
            {
                //This is a new invoice as the id is zero
                commandText = "Insert into dbo.Invoices (Customer_Id, Description, Cost, Payment_Date)" +
                                        "values(@Customer_Id, @Description, @Cost, @Payment_Date)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Parameters.Add("@Customer_Id", SqlDbType.Int);
                        command.Parameters.Add("@Description", SqlDbType.VarChar);
                        command.Parameters.Add("@Cost", SqlDbType.Float);
                        command.Parameters.Add("@Payment_Date", SqlDbType.Date);

                        command.Parameters["@Customer_Id"].Value = invoice.Customer_Id;
                        command.Parameters["@Description"].Value = invoice.Description;
                        command.Parameters["@Cost"].Value = invoice.Costs;
                        command.Parameters["@Payment_Date"].Value = invoice.Payment_Date;


                        connection.Open();
                        numberRowsAdded = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw (new Exception(errorMessage, ex));
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
                    try
                    {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters.Add("@Customer_Id", SqlDbType.Int);
                    command.Parameters.Add("@Description", SqlDbType.VarChar);
                    command.Parameters.Add("@Cost", SqlDbType.Float);
                    command.Parameters.Add("@Payment_Date", SqlDbType.Date);

                    command.Parameters["@Id"].Value = invoice.Id;
                    command.Parameters["@Customer_Id"].Value = invoice.Customer_Id;
                    command.Parameters["@Description"].Value = invoice.Description;
                    command.Parameters["@Cost"].Value = invoice.Costs;
                    command.Parameters["@Payment_Date"].Value = invoice.Payment_Date;

                    
                        connection.Open();
                        numberRowsAdded = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw (new Exception(errorMessage, ex));
                    }
                }
            }

            return ((IInvoiceService)this).GetCustomerInvoices(invoice.Customer_Id);
        }

        public List<Invoice> GetInvoicesById(int Id)
        {
            List<Invoice> returnList = new List<Models.Invoice>();

            commandText = "select Id, Cost, Description, Payment_Date, Customer_Id, Cost " +
                            "from Invoices where IsDeleted = 0 and Id = @Invoice_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Invoice_Id", SqlDbType.Int);

                command.Parameters["@Invoice_Id"].Value = Id;

                SqlDataReader reader = null;
                
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnList.Add(new Invoice
                        {
                            Id = (int)reader["Id"],
                            Costs = (double)reader["Cost"],
                            Description = (string)reader["Description"],
                            Payment_Date = Convert.ToDateTime(reader["Payment_Date"]),
                            Customer_Id = (int)reader["Customer_Id"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw (new Exception(errorMessage, ex));
                }
            }

            return returnList;
        }

        public List<Invoice> GetCustomerInvoices(int Customer_Id)
        {
            List<Invoice> returnList = new List<Models.Invoice>();

            commandText = "select Id, Cost, Description, Payment_Date, Customer_Id " +
                            "from Invoices where IsDeleted = 0 and Customer_Id = @Customer_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                { 
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Customer_Id", SqlDbType.Int);

                command.Parameters["@Customer_Id"].Value = Customer_Id;

                SqlDataReader reader = null;

                    connection.Open();
                    reader = command.ExecuteReader();

                    // write each record
                    while (reader.Read())
                    {
                        returnList.Add(new Invoice
                        {
                            Id = (int)reader["Id"],

                            Costs = (double)reader["Cost"],

                            Description = (string)reader["Description"],

                            Payment_Date = Convert.ToDateTime(reader["Payment_Date"]),

                            Customer_Id = (int)reader["Customer_Id"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw (new Exception(errorMessage, ex));
                }
            }

            return returnList;
        }

        public int GetMaxInvoiceId()
        {
            int returnValue = -1;
            commandText = "Select MAX(id) + 1 as Next_Invoice_ID from Invoices";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                SqlCommand command = new SqlCommand(commandText, connection);

                SqlDataReader reader = null;
                
                    connection.Open();
                    reader = command.ExecuteReader();

                    // write each record
                    while (reader.Read())
                    {
                        returnValue = (int)reader["Next_Invoice_ID"];
                    }
                }
                catch (Exception ex)
                {
                    throw (new Exception(errorMessage, ex));
                }
            }

            return returnValue;
        }

        public void DeleteInvoiceById(int Id)
        {
            int numberRowsAdded;

            commandText = "Update Invoices " +
                            "Set IsDeleted = 1" +
                            "Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Id", SqlDbType.Int);

                    command.Parameters["@Id"].Value = Id;

                    connection.Open();
                    numberRowsAdded = command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    throw (new Exception(errorMessage, ex));
                }
            }
        }
    }
}
